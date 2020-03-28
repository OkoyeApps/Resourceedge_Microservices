using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Helpers;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
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

        public AppraisalResultService(IDbContext _context, IMapper _mapper)
        {
            Collection = _context.Database.GetCollection<AppraisalResult>($"{nameof(AppraisalResult)}s");
            KraCollection = _context.Database.GetCollection<KeyResultArea>($"{nameof(KeyResultArea)}s");

            context = _context;
            mapper = _mapper;
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

        public void SubmitAppraisal(AppraisalResultForCreationDto entity)
        {

            var filter = Builders<AppraisalResult>.Filter.Where(a => a.myId == entity.myId && a.AppraisalConfigId == entity.AppraisalConfigId && a.AppraisalCycleId == entity.AppraisalCycleId && a.KeyResultArea.Id == entity.KeyResultAreaId);
            var result = Collection.Find(a => a.myId == entity.myId && a.AppraisalConfigId == entity.AppraisalConfigId && a.AppraisalCycleId == entity.AppraisalCycleId && a.KeyResultArea.Id == entity.KeyResultAreaId).FirstOrDefault();

            if (entity.whoami == null)
            {
                var keyResultArea = KraCollection.Find(r => r.Id == entity.KeyResultAreaId).FirstOrDefault();
                var myAppraisal = mapper.Map<AppraisalResult>(entity);

                myAppraisal.KeyResultArea = keyResultArea;
                this.InsertResult(myAppraisal);
            }
            else if (entity.whoami == "APPRAISAL")
            {
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
                        result.CurrentSupervisor = "Appraisal";
                        result.AppraiseeFeedBack = item.AppraiseeFeedBack;
                    }
                }
                var entityToUpdate = result.ToBsonDocument();
                var update = new BsonDocument("$set", entityToUpdate);
                Collection.FindOneAndUpdate(filter, update, options: new FindOneAndUpdateOptions<AppraisalResult> { ReturnDocument = ReturnDocument.After });
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
            }
        }
        
        public async Task<UpdateResult> EmployeeAcceptOrReject(ObjectId appraisalResultId, AcceptanceStatus status)
        {
            var filter = Builders<AppraisalResult>.Filter.Eq("Id", appraisalResultId);
            var appraisalResult = Collection.Find(filter).FirstOrDefault();

            if(appraisalResult != null)
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

            if (appraisalResult != null)
            {
                appraisalResult.HodAccept.IsAccepted = status.IsAccepted.Value;

                var newAppraisalResult = appraisalResult.HodApproval(status.Reason);
                var entityToUpdate = newAppraisalResult.ToBsonDocument();
                var update = new BsonDocument("$set", entityToUpdate);

                return await Collection.UpdateOneAsync(filter, update);
            }

            return null;

        }
    }
}
