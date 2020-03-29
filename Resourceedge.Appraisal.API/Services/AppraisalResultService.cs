using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Helpers;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Common.Archive;
using Resourceedge.Email.Api.Model;
using Resourceedge.Email.Api.SGridClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Services
{
    public class AppraisalResultService : IAppraisalResult
    {
        public readonly IMongoCollection<AppraisalResult> Collection;
        public readonly IMongoCollection<KeyResultArea> KraCollection;
        private readonly IDbContext context;
        private readonly IMapper mapper;
        private readonly IKeyResultArea resultAreaRepo;
        private EmailSender sender;
        

        public AppraisalResultService(IDbContext _context, IMapper _mapper, ISGClient _client, IKeyResultArea _resultAreaRepo)
        {
            Collection = _context.Database.GetCollection<AppraisalResult>($"{nameof(AppraisalResult)}s");
            KraCollection = _context.Database.GetCollection<KeyResultArea>($"{nameof(KeyResultArea)}s");

            context = _context;
            mapper = _mapper;
            resultAreaRepo = _resultAreaRepo;
            sender = new EmailSender(_client);
        }

        public IEnumerable<AppraisalResult> Get(ObjectId AppraisalConfigId, ObjectId CycleId, int? EmployeeId)
        {
            var result = Collection.AsQueryable().Where(a => a.myId == EmployeeId && a.AppraisalConfigId == AppraisalConfigId && a.AppraisalCycleId == CycleId);
            return result.ToList();
        }

        public void InsertResult(AppraisalResult entity)
        {
            Collection.InsertOne(entity);
        }

        public async void SubmitAppraisal(AppraisalResultForCreationDto entity)
        {

            var filter = Builders<AppraisalResult>.Filter.Where(a => a.myId == entity.myId && a.AppraisalConfigId == entity.AppraisalConfigId && a.AppraisalCycleId == entity.AppraisalCycleId && a.KeyResultArea.Id == entity.KeyResultAreaId);
            var result = Collection.Find(a => a.myId == entity.myId && a.AppraisalConfigId == entity.AppraisalConfigId && a.AppraisalCycleId == entity.AppraisalCycleId && a.KeyResultArea.Id == entity.KeyResultAreaId).FirstOrDefault();
            var keyResultArea = await resultAreaRepo.QuerySingle(entity.KeyResultAreaId);
            var employee = await resultAreaRepo.GetEmployee(entity.myId);
            
            string subject = $"Pending Appraisal for {employee.FullName}";
            string msg = $"has submitted his/her appraisal for the key result area {keyResultArea.Name}, Kindly attend to it as soon as possible.";
            string title = "Approval For Approval";
            SingleEmailDto emailDto = new SingleEmailDto();
            if (entity.whoami == null)
            {
                var myAppraisal = mapper.Map<AppraisalResult>(entity);

                myAppraisal.KeyResultArea = keyResultArea;
                this.InsertResult(myAppraisal);

                emailDto = new SingleEmailDto()
                {
                    ReceiverFullName = keyResultArea.AppraiserDetails.Name, 
                    ReceiverEmailAddress = keyResultArea.AppraiserDetails.Email,
                    HtmlContent = await sender.FormatEmail(employee.FullName, keyResultArea.AppraiserDetails.Name, msg, title),
                };
            }
            else if (entity.whoami == "APPRAISAL")
            {
                result.CurrentSupervisor = "Appraisal";
                result.AppraiseeFeedBack = entity.AppraiseeFeedBack;
                foreach (var item in entity.KeyOutcomeScore)
                {
                    if (result.KeyOutcomeScore.Any(a => a.KeyOutcomeId == item.KeyOutcomeId))
                    {
                        foreach (var item1 in result.KeyOutcomeScore)
                        {
                            if (item.KeyOutcomeId == item1.KeyOutcomeId)
                            {
                                result.KeyOutcomeScore.FirstOrDefault(x => x.KeyOutcomeId == item1.KeyOutcomeId).AppraisalScore = item.EmployeeScore;
                            }
                        }                     
                    }
                }
                var entityToUpdate = result.ToBsonDocument();
                var update = new BsonDocument("$set", entityToUpdate);
                Collection.FindOneAndUpdate(filter, update, options: new FindOneAndUpdateOptions<AppraisalResult> { ReturnDocument = ReturnDocument.After });

                emailDto = new SingleEmailDto()
                {
                    ReceiverFullName = keyResultArea.HodDetails.Name,
                    ReceiverEmailAddress = keyResultArea.HodDetails.Email,
                    HtmlContent = await sender.FormatEmail(employee.FullName, keyResultArea.HodDetails.Name, msg, title),
                };
            }
            else if (entity.whoami == "HOD")
            {
                foreach (var item in entity.KeyOutcomeScore)
                {
                    if (result.KeyOutcomeScore.Any(a => a.KeyOutcomeId == item.KeyOutcomeId))
                    {
                        foreach (var item1 in result.KeyOutcomeScore)
                        {
                            if (item.KeyOutcomeId == item1.KeyOutcomeId)
                            {
                                result.KeyOutcomeScore.FirstOrDefault(x => x.KeyOutcomeId == item1.KeyOutcomeId).HodScore = item.EmployeeScore;
                            }
                        }
                    }
                }
                var entityToUpdate = result.ToBsonDocument();
                var update = new BsonDocument("$set", entityToUpdate);
                Collection.FindOneAndUpdate(filter, update, options: new FindOneAndUpdateOptions<AppraisalResult> { ReturnDocument = ReturnDocument.After });
                msg = $"who is your HOD has completed your appraisal for the key result area {keyResultArea.Name}, You are to accept or reject it";
                emailDto = new SingleEmailDto()
                {
                    ReceiverFullName = employee.FullName,
                    ReceiverEmailAddress = employee.Email,
                    HtmlContent = await sender.FormatEmail(keyResultArea.HodDetails.Name, employee.FullName,  msg, title),
                };

            }
           await sender.SendToSingleEmployee(subject, emailDto);
        }

        public async Task<UpdateResult> EmployeeAcceptOrReject(ObjectId appraisalResultId, AcceptanceStatus status)
        {
            var filter = Builders<AppraisalResult>.Filter.Eq("Id", appraisalResultId);
            var appraisalResult = Collection.Find(filter).FirstOrDefault();

            if (appraisalResult != null)
            {
                appraisalResult.EmployeeAccept.IsAccepted = status.IsAccepted.Value;

                var newAppraisalResult = appraisalResult.CompleteAppraisal(status.Reason);
                var entityToUpdate = newAppraisalResult.ToBsonDocument();
                var update = new BsonDocument("$set", entityToUpdate);

                return await Collection.UpdateOneAsync(filter, update);
            }
            return null;
        }

        public async Task<UpdateResult> HodApprovalOrReject(ObjectId appraisalResultId, AcceptanceStatus status)
        {
            var filter = Builders<AppraisalResult>.Filter.Eq("Id", appraisalResultId);
            var appraisalResult = Collection.Find(filter).FirstOrDefault();
            var employee = await resultAreaRepo.GetEmployee(appraisalResult.KeyResultArea.EmployeeId);

            string subject = $"Pending Approval";
            string msg = $"who is your HOD has completed your appraisal for the key result area {appraisalResult.KeyResultArea.Name}, You are to accept or reject it";
            string title = "Approval For Approval";

            if (appraisalResult != null)
            {
                appraisalResult.HodAccept.IsAccepted = status.IsAccepted.Value;

                var newAppraisalResult = appraisalResult.HodApproval(status.Reason);
                var entityToUpdate = newAppraisalResult.ToBsonDocument();
                var update = new BsonDocument("$set", entityToUpdate);


                SingleEmailDto emailDto = new SingleEmailDto()
                {
                    ReceiverFullName = employee.FullName,
                    ReceiverEmailAddress = employee.Email,
                    HtmlContent = await sender.FormatEmail(appraisalResult.KeyResultArea.HodDetails.Name, employee.FullName, msg, title),
                };

                var res = await Collection.UpdateOneAsync(filter, update);
                if(res.MatchedCount > 0)
                {
                    await sender.SendToSingleEmployee(subject, emailDto); 
                }

                return res;

            }
            return null;
        }
    }
}
