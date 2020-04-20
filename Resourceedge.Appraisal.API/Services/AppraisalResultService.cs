using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Helpers;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Common.Util;
using Resourceedge.Appraisal.Domain.Queries;
using Resourceedge.Email.Api.Interfaces;
using Resourceedge.Email.Api.Model;
using Resourceedge.Email.Api.SGridClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Resourceedge.Appraisal.API.DBQueries;
using System.Linq.Expressions;

namespace Resourceedge.Appraisal.API.Services
{
    public class AppraisalResultService : IAppraisalResult
    {
        public readonly IMongoCollection<AppraisalResult> Collection;
        public readonly IMongoCollection<KeyResultArea> KraCollection;
        public readonly IMongoCollection<AppraisalConfig> AppraisalConfigCollection;
        private readonly IDbContext context;
        private readonly IMapper mapper;
        private readonly IKeyResultArea resultAreaRepo;
        private readonly IEmailSender sender;
        private readonly ITeamRepository teamRepository;

        public AppraisalResultService(IDbContext _context, IMapper _mapper, ISGClient _client, IKeyResultArea _resultAreaRepo, IEmailSender _sender, ITeamRepository _teamRepository)
        {
            Collection = _context.Database.GetCollection<AppraisalResult>($"{nameof(AppraisalResult)}s");
            KraCollection = _context.Database.GetCollection<KeyResultArea>($"{nameof(KeyResultArea)}s");

            context = _context;
            mapper = _mapper;
            resultAreaRepo = _resultAreaRepo;
            sender = _sender;
            teamRepository = _teamRepository;
            AppraisalConfigCollection = _context.Database.GetCollection<AppraisalConfig>($"{nameof(AppraisalConfig)}s");


        }

        public IEnumerable<AppraisalResult> Get(ObjectId AppraisalConfigId, ObjectId CycleId, int? EmployeeId)
        {
            var configDetails = AppraisalConfigCollection.AsQueryable().FirstOrDefault(x => x.Id == AppraisalConfigId).Cycles.FirstOrDefault(x => x.Id == CycleId);
            var result = Collection.AsQueryable().Where(a => a.myId == EmployeeId && a.AppraisalConfigId == AppraisalConfigId && a.AppraisalCycleId == CycleId);
            return result.ToList();
        }

        public void InsertResult(AppraisalResult entity)
        {
            Collection.InsertOne(entity);
        }

        public async Task<bool> SubmitAppraisal(int empId, IEnumerable<AppraisalResultForCreationDto> entities)
        {
            var employee = await resultAreaRepo.GetEmployee(entities.FirstOrDefault().myId);
            string title = "Pending Appraisal";
            string msg = $"has performed his/her appraisal for these quarter, Kindly attend to it as soon as possible.";
            string url = "https://resourceedge.herokuapp.com/";
            string subject = "";
            List<SingleEmailDto> emailDto = new List<SingleEmailDto>();
            SingleEmailDto email = new SingleEmailDto();

            if (employee != null)
            {
                subject = $"Pending Appraisal for {employee.FullName}";

                try
                {
                    foreach (var entity in entities)
                    {
                        var filter = Builders<AppraisalResult>.Filter.Where(a => a.myId == empId
                                                                            && a.AppraisalConfigId == entity.AppraisalConfigId
                                                                            && a.AppraisalCycleId == entity.AppraisalCycleId
                                                                            && a.KeyResultArea.Id == entity.KeyResultAreaId);

                        var keyResultArea = await resultAreaRepo.QuerySingle(entity.KeyResultAreaId);

                        if (entity.whoami == null)
                        {
                            var myAppraisal = mapper.Map<AppraisalResult>(entity);
                            myAppraisal.NextAppraisee = "Appraiser";
                            myAppraisal.EmployeeAccept.IsAccepted = true;

                            myAppraisal.KeyResultArea = keyResultArea;
                            var average = myAppraisal.KeyOutcomeScore.Average(x => x.EmployeeScore.Value);
                            myAppraisal.EmployeeCalculation.ScoreTotal = myAppraisal.KeyOutcomeScore.Sum(x => x.EmployeeScore).Value;
                            myAppraisal.EmployeeCalculation.Average = average;
                            myAppraisal.EmployeeCalculation.WeightContribution = (average * (Convert.ToDouble(myAppraisal.KeyResultArea.Weight)) / 100);

                            this.InsertResult(myAppraisal);

                            email.ReceiverFullName = keyResultArea.AppraiserDetails.Name;
                            email.ReceiverEmailAddress = keyResultArea.AppraiserDetails.Email;
                            email.HtmlContent = await sender.FormatEmail(employee.FullName, keyResultArea.AppraiserDetails.Name, msg, title, url);
                            
                            if (email.HtmlContent == null)
                            {
                                email.HtmlContent = @$"<p>{employee.FullName} has participated in these quarter, kindly login to resourceedge and Appraise him/her.</p>";
                            }
                            emailDto.Add(email);
                        }
                    }

                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    var emailDtos = AppraisalResultExtension.FormatEmailForAppraisal(emailDto);

                    if (emailDtos.Any())
                    {
                        emailDtos.ForEach(async e => await sender.SendToSingleEmployee(subject, e));
                    }
                }
            }
            return true;
        }

        public async Task<bool> AppraiseEmployee(int empId, IEnumerable<AppraisalResultForCreationDto> entities)
        {
            var employee = await resultAreaRepo.GetEmployee(empId);
            string title = "Pending Appraisal";
            string subject = "";
            string msg = $"has performed his/her appraisal for these quarter, Kindly attend to it as soon as possible.";
            string url = "https://resourceedge.herokuapp.com/";
            List<SingleEmailDto> emailDto = new List<SingleEmailDto>();
            SingleEmailDto email = new SingleEmailDto();

            if (employee != null)
            {
                try
                {
                    foreach (var entity in entities)
                    {
                        var filter = Builders<AppraisalResult>.Filter.Where(a => a.myId == empId && a.AppraisalConfigId == entity.AppraisalConfigId && a.AppraisalCycleId == entity.AppraisalCycleId && a.KeyResultArea.Id == entity.KeyResultAreaId);
                        var result = Collection.Find(a => a.myId == empId && a.AppraisalConfigId == entity.AppraisalConfigId && a.AppraisalCycleId == entity.AppraisalCycleId
                        && a.KeyResultArea.Id == entity.KeyResultAreaId).FirstOrDefault();

                        if (entity.whoami == "APPRAISER")
                        {
                            if (result.NextAppraisee == "Hod")
                            {
                                return false;
                            }

                            if (result == null)
                            {
                                return false;
                            }

                            result.AppraiseeFeedBack = entity.AppraiseeFeedBack;
                            result.NextAppraisee = "Hod";
                            result.IsAccepted = true;

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

                            var average = result.KeyOutcomeScore.Average(x => x.AppraisalScore.Value);
                            result.AppraiseeCalculation.ScoreTotal = result.KeyOutcomeScore.Sum(x => x.AppraisalScore.Value);
                            result.AppraiseeCalculation.Average = average;
                            result.AppraiseeCalculation.WeightContribution = (average * (Convert.ToDouble(result.KeyResultArea.Weight) / 100));


                            if (result.KeyResultArea.HodDetails.EmployeeId == result.KeyResultArea.AppraiserDetails.EmployeeId)
                            {
                                result.HodAccept.IsAccepted = true;
                                result = result.HodApproval("");
                                result.FinalCalculation.ScoreTotal = result.KeyOutcomeScore.Sum(x => x.AppraisalScore.Value);
                                result.FinalCalculation.Average = average;
                                result.FinalCalculation.WeightContribution = (average * (Convert.ToDouble(result.KeyResultArea.Weight) / 100));
                            }

                            var entityToUpdate = result.ToBsonDocument();
                            var update = new BsonDocument("$set", entityToUpdate);
                            Collection.FindOneAndUpdate(filter, update, options: new FindOneAndUpdateOptions<AppraisalResult> { ReturnDocument = ReturnDocument.After });

                            email.ReceiverFullName = result.KeyResultArea.HodDetails.Name;
                            email.ReceiverEmailAddress = result.KeyResultArea.HodDetails.Email;
                            email.HtmlContent = await sender.FormatEmail(employee.FullName, result.KeyResultArea.HodDetails.Name, msg, title, url);

                            if (email.HtmlContent == null)
                            {
                                email.HtmlContent = @$"<p>{result.KeyResultArea.AppraiserDetails.Name} has Completed your appraisal for these quarter, kindly login to resourceedge and View your result.</p>";
                            }
                            emailDto.Add(email);
                        }
                        else if (entity.whoami == "HOD")
                        {

                            if (result.NextAppraisee == "Done")
                            {
                                return false;
                            }

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

                            result.AppraiseeFeedBack = entity.AppraiseeFeedBack;
                            result.HodAccept.IsAccepted = true;
                            var average = result.KeyOutcomeScore.Average(x => x.HodScore.Value);
                            result.FinalCalculation.ScoreTotal = result.KeyOutcomeScore.Sum(x => x.HodScore.Value);
                            result.FinalCalculation.Average = average;
                            result.FinalCalculation.WeightContribution = (average * (Convert.ToDouble(result.KeyResultArea.Weight)) / 100);

                            var newAppraisalResult = result.HodApproval("");
                            var entityToUpdate = newAppraisalResult.ToBsonDocument();
                            var update = new BsonDocument("$set", entityToUpdate);
                            Collection.FindOneAndUpdate(filter, update, options: new FindOneAndUpdateOptions<AppraisalResult> { ReturnDocument = ReturnDocument.After });
                            msg = $"who is your HOD has completed your appraisal for the key result area {result.KeyResultArea.Name}, You are to accept or reject it";

                            email.ReceiverFullName = employee.FullName;
                            email.ReceiverEmailAddress = employee.Email;
                            email.HtmlContent = await sender.FormatEmail(result.KeyResultArea.HodDetails.Name, employee.FullName, msg, title, url);

                            if (email.HtmlContent == null)
                            {
                                email.HtmlContent = @$"<p>{result.KeyResultArea.HodDetails.Name} has Completed your appraisal for these quarter, kindly login to resourceedge and View your result.</p>";
                            }
                            emailDto.Add(email);
                        }
                    }

                }
                catch (Exception)
                {

                    return false;
                }
                finally
                {
                    var emailDtos = AppraisalResultExtension.FormatEmailForAppraisal(emailDto);

                    if (emailDtos.Any())
                    {
                        emailDtos.ForEach(async e => await sender.SendToSingleEmployee(subject, e));
                    }
                }
            }

            return true;

        }

        public async Task<UpdateResult> EmployeeAcceptOrReject(ObjectId appraisalResultId, AcceptanceStatus status)
        {
            var filter = Builders<AppraisalResult>.Filter.Eq("Id", appraisalResultId);
            var appraisalResult = Collection.Find(filter).FirstOrDefault();

            if (appraisalResult != null)
            {
                appraisalResult.EmployeeAccept = new AcceptanceStatus()
                {
                    IsAccepted = status.IsAccepted.Value
                };

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
            string url = "https://resourceedge.herokuapp.com/";
            if (appraisalResult != null)
            {
                appraisalResult.HodAccept = new AcceptanceStatus()
                {
                    IsAccepted = status.IsAccepted.Value
                };

                var newAppraisalResult = appraisalResult.HodApproval(status.Reason);
                var entityToUpdate = newAppraisalResult.ToBsonDocument();
                var update = new BsonDocument("$set", entityToUpdate);

                SingleEmailDto emailDto = new SingleEmailDto()
                {
                    ReceiverFullName = employee.FullName,
                    ReceiverEmailAddress = employee.Email,
                    HtmlContent = await sender.FormatEmail(appraisalResult.KeyResultArea.HodDetails.Name, employee.FullName, msg, title, url),
                };

                var res = await Collection.UpdateOneAsync(filter, update);
                if (res.MatchedCount > 0)
                {
                    await sender.SendToSingleEmployee(subject, emailDto);
                }
                return res;
            }
            return null;
        }

        public async Task<IEnumerable<AppraisalForApprovalDto>> GetEmployeesToAppraise(int employeeId, string appraisalConfigurationId, string appraisalCycleId, string whoAmI)
        {
            var year = DateTime.Now.Year;
            var pipeline = SupervisorEmployeeQuery.GetEmployeesToAppraise(employeeId, appraisalConfigurationId, appraisalCycleId);
            var lookupResult = KraCollection.Aggregate<AppraisalForApprovalDto>(pipeline);

            var finalResultToReturn = await GenerateDistinctArrayForEmployeeKRA(lookupResult);
            //var result = lookupResult.ToList();
            if (finalResultToReturn.Count > 0)
            {
                //get Equivalent Employee Details for each one
                IEnumerable<string> IdsToSend = finalResultToReturn.Select(x => x.EmployeeDetail.EmployeeId.ToString()).Distinct();
                var returnedEmployees = await teamRepository.FetchEmployeesDetailsFromEmployeeService(IdsToSend);
                if (returnedEmployees.Any())
                {
                    foreach (var employee in returnedEmployees)
                    {
                        var currentEmployee = finalResultToReturn.FirstOrDefault(x => x.EmployeeDetail.EmployeeId == employee.EmployeeId);
                        currentEmployee.EmployeeDetail.Email = employee.Email;
                        currentEmployee.EmployeeDetail.EmpStaffId = employee.StaffId;
                        currentEmployee.EmployeeDetail.FullName = employee.FullName;
                        currentEmployee.EmployeeDetail.Company = employee.Subgroup.Name;
                    }
                }
            }
            return finalResultToReturn;
        }

        private async Task<List<AppraisalForApprovalDto>> GenerateDistinctArrayForEmployeeKRA(IAsyncCursor<AppraisalForApprovalDto> model)
        {
            var computedArray = new List<AppraisalForApprovalDto>();
            await model.ForEachAsync(item =>
            {
                if (!computedArray.Any(x => x.EmployeeDetail.EmployeeId == item.EmployeeDetail.EmployeeId))
                {
                    computedArray.Add(item);
                }
                else
                {
                    var oldResult = computedArray.FirstOrDefault(x => x.EmployeeDetail.EmployeeId == item.EmployeeDetail.EmployeeId);
                    if (oldResult != null)
                    {
                        var oldKra = oldResult.Kra_Details.ToList();
                        oldKra.AddRange(item.Kra_Details);
                        oldResult.Kra_Details = oldKra;
                    }
                }
            });

            return computedArray;
        }

        public async Task<bool> HasPaticipatedInAppraisal(int employeeId)
        {
            var result = Collection.AsQueryable().Any(x => x.myId == employeeId);
            return result;
        }

        public async Task<bool> CheckAppraisalConfigurationDetails(AppraisalQueryParam model)
        {
            return AppraisalConfigCollection.AsQueryable().Any(x => x.Id == ObjectId.Parse(model.Config) && x.Cycles.Any(y => y.Id == ObjectId.Parse(model.Cycle)));
        }

        public async Task<bool> CheckMultipleAppraisalConfigurationDetails(IEnumerable<AppraisalQueryParam> model)
        {
            foreach (var item in model)
            {
                var res = await CheckAppraisalConfigurationDetails(item);
                if (!res)
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<KeyResultArea> GetAcceptedKRAForAppraisal(int userId, AppraisalCycle configParam, string resultId = null)
        {
            if (resultId != null)
            {
                ObjectId Id = new ObjectId(resultId);
                return KraCollection.AsQueryable().Where(x => x.EmployeeId == userId && x.Id == Id && x.Approved == true && x.Status.Employee == true && x.Year == DateTime.Now.Year).ToList();
            }

             Func<KeyOutcome,  bool> function  = (x) => GetApplicableKeyOutcomes(x, configParam);
            var year = DateTime.Now.Year;
            return KraCollection.AsQueryable().Where(x => x.EmployeeId == userId && x.Approved == true && x.Status.Employee == true && x.Year == year).ToList()
                .Select(x => new KeyResultArea
                {
                    keyOutcomes = x.keyOutcomes.Where(y => GetApplicableKeyOutcomes(y, configParam)),
                    EmployeeId = x.EmployeeId,
                    AppraiserDetails = x.AppraiserDetails,
                    Approved = x.Approved,
                    HodDetails = x.HodDetails,
                    IsActive = x.IsActive,
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status,
                    UserId = x.UserId,
                    Weight = x.Weight,
                    Year = x.Year
                });
        }

        private bool GetApplicableKeyOutcomes(KeyOutcome keyOutcome, AppraisalCycle cycle)
        {
            DateTime parsedDate;
            var valid = DateTime.TryParse(keyOutcome.TimeLimit, out  parsedDate);
            if (!valid)
            {
                //check if the values are 
                var regex = new Regex("(continously)|(yearly)|(annually)|(weekly)|(quaterly)|(continous)|(ongoing)");
                var passedRegex = regex.IsMatch(keyOutcome.TimeLimit.ToLower());
                if (passedRegex)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (parsedDate <= cycle.StopDate)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<AppraisalConfig> GetAppraisalConfiguration(string configid)
        {
            var result = AppraisalConfigCollection.AsQueryable().FirstOrDefault(x => x.Id == ObjectId.Parse(configid));
            return await Task.FromResult(result);
        }
    }


}
