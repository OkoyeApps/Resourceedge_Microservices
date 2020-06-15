using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.DBQueries;
using Resourceedge.Appraisal.API.Helpers;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Appraisal.Domain.Queries;
using Resourceedge.Email.Api.Interfaces;
using Resourceedge.Email.Api.Model;
using Resourceedge.Email.Api.SGridClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Resourceedge.Appraisal.API.DBQueries;
using System.Linq.Expressions;
using System.Globalization;
using System.Diagnostics;
using Resourceedge.Common.Archive;
using Microsoft.AspNetCore.Mvc;

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
        private readonly IAppraisalFinalResult finalResultRepo;

        public AppraisalResultService(IDbContext _context, IMapper _mapper, ISGClient _client, IKeyResultArea _resultAreaRepo, IEmailSender _sender, ITeamRepository _teamRepository, IAppraisalFinalResult _finalResultRepo)
        {
            Collection = _context.Database.GetCollection<AppraisalResult>($"{nameof(AppraisalResult)}s");
            KraCollection = _context.Database.GetCollection<KeyResultArea>($"{nameof(KeyResultArea)}s");

            context = _context;
            mapper = _mapper;
            resultAreaRepo = _resultAreaRepo;
            sender = _sender;
            teamRepository = _teamRepository;
            finalResultRepo = _finalResultRepo;
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

        public async Task<(bool,string)> SubmitAppraisal(int empId, IEnumerable<AppraisalResultForCreationDto> entities)
        {
            var employee = await resultAreaRepo.GetEmployee(entities.FirstOrDefault().myId);
            string title = "Appraise";
            string msg = $"has successfully appraised self. Kindly login to the portal to view. <br /> Thank you.</p>";
            string url = "https://resourceedge.herokuapp.com/";
            string subject = "";
            List<SingleEmailDto> emailDto = new List<SingleEmailDto>();
            SingleEmailDto email = new SingleEmailDto();

            if (employee != null)
            {
                subject = $"Appraise {employee.FullName}";

                try
                {
                    foreach (var entity in entities)
                    {

                        var keyResultArea = GetOnlyApplicableKeyoutcomesForAppraisal(entity.KeyResultAreaId, empId, entity.KeyOutcomeScore.Select(x => x.KeyOutcomeId.ToString()).ToList()).FirstOrDefault();
                        if(keyResultArea == null)
                        {
                            return (false, "No Key Result Area Found, Invalid Key result area Id");
                        }
                        //var keyResultArea = await resultAreaRepo.QuerySingle(entity.KeyResultAreaId);

                        if (entity.whoami == null)
                        {
                            var myAppraisal = mapper.Map<AppraisalResult>(entity);
                            myAppraisal.NextAppraisee = "Appraiser";
                            myAppraisal.EmployeeAccept.IsAccepted = true;

                            myAppraisal.KeyResultArea = keyResultArea;
                            var average = myAppraisal.KeyOutcomeScore.Where(x => x.EmployeeScore != null).Average(x => x.EmployeeScore.Value);
                            myAppraisal.EmployeeCalculation.ScoreTotal = myAppraisal.KeyOutcomeScore.Where(x => x.EmployeeScore != null).Sum(x => x.EmployeeScore).Value;
                            myAppraisal.EmployeeCalculation.Average = average;
                            myAppraisal.EmployeeCalculation.WeightContribution = (average * (Convert.ToDouble(myAppraisal.KeyResultArea.Weight)) / 100);

                            this.InsertResult(myAppraisal);

                            email.ReceiverFullName = keyResultArea.AppraiserDetails.Name;
                            email.ReceiverEmailAddress = keyResultArea.AppraiserDetails.Email;
                            email.HtmlContent = await sender.FormatEmail(employee.FullName, keyResultArea.AppraiserDetails.Name, msg, title, url);

                            if (email.HtmlContent == null)
                            {
                                email.HtmlContent = @$"<b>Dear {myAppraisal.KeyResultArea.AppraiserDetails.Name},</b> <br /> <p>{employee.FullName} has successfully appraised self. Kindly login to the portal and appraise him/her.<br /><br /> Thank you.</p>";

                            }
                            emailDto.Add(email);
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (false, "Oops something went wrong");
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
            return (true, "Appraisal Submitted Successfull");
        }

        public async Task<bool> AppraiseEmployee(int empId, IEnumerable<AppraisalResultForCreationDto> entities)
        {
            var employee = await resultAreaRepo.GetEmployee(empId);
            //string title = "Appraised Done";
            //string subject = "";
            //string msg = $"has successfully appraised self. Kindly login to the portal and appraise him/her. <br /> Thank you.</p>";
            //string url = "https://resourceedge.herokuapp.com/";
            //List<SingleEmailDto> emailDto = new List<SingleEmailDto>();
            //SingleEmailDto email = new SingleEmailDto();

            if (employee != null)
            {
                try
                {
                    foreach (var entity in entities)
                    {
                        var filter = Builders<AppraisalResult>.Filter.Where(a => a.myId == empId
                                                                            && a.AppraisalConfigId == entity.AppraisalConfigId
                                                                            && a.AppraisalCycleId == entity.AppraisalCycleId
                                                                            && a.KeyResultArea.Id == entity.KeyResultAreaId);
                        var result = Collection.Find(filter).FirstOrDefault();

                        if (result == null)
                        {
                            return false;
                        }

                        if (entity.whoami == "APPRAISER")
                        {
                            if (result.KeyResultArea.AppraiserDetails.EmployeeId != entity.myId)
                                continue;
                            else if (result.NextAppraisee == "Hod")
                                continue;                            

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

                            result.AppraiseeCalculation.ScoreTotal = result.KeyOutcomeScore.Where(x => x.AppraisalScore != null).Sum(x => x.AppraisalScore.Value);
                            var average = result.KeyOutcomeScore.Where(x => x.AppraisalScore != null).Average(x => x.AppraisalScore.Value);
                            result.AppraiseeCalculation.Average = average;
                            result.AppraiseeCalculation.WeightContribution = (average * (Convert.ToDouble(result.KeyResultArea.Weight) / 100));
                            result.AppraiseeFeedBack = entity.AppraiseeFeedBack;
                            result.NextAppraisee = "Hod";

                            if (result.KeyResultArea.HodDetails.EmployeeId == result.KeyResultArea.AppraiserDetails.EmployeeId)
                            {
                                result.HodAccept.IsAccepted = true;
                                result = result.HodApproval("");
    
                                result.FinalCalculation.ScoreTotal = result.KeyOutcomeScore.Where(x => x.AppraisalScore != null).Sum(x => x.AppraisalScore.Value);
                                result.FinalCalculation.Average = average;
                                result.FinalCalculation.WeightContribution = (average * (Convert.ToDouble(result.KeyResultArea.Weight) / 100));
                            }

                            var entityToUpdate = result.ToBsonDocument();
                            var update = new BsonDocument("$set", entityToUpdate);
                            Collection.FindOneAndUpdate(filter, update, options: new FindOneAndUpdateOptions<AppraisalResult> { ReturnDocument = ReturnDocument.After });

                            //email.ReceiverFullName = result.KeyResultArea.Name;
                            //email.ReceiverEmailAddress = result.KeyResultArea.HodDetails.Email;
                            //email.HtmlContent = await sender.FormatEmail(employee.FullName, result.KeyResultArea.HodDetails.Name, msg, title, url);

                            //if (email.HtmlContent == null)
                            //{
                            //    email.HtmlContent = @$"<b>Dear {result.KeyResultArea.HodDetails.Name},</b> <br /> <br /> <p>{result.KeyResultArea.AppraiserDetails.Name} has successfully appraised {employee.FullName}. Kindly login to the portal and review. <br /><br /> Thank you.</p>";

                            //}
                            //emailDto.Add(email);
                        }
                        //else if (entity.whoami == "HOD")
                        //{

                        //    if (result.NextAppraisee == "Done")
                        //    {
                        //        continue;
                        //    }

                        //    //foreach (var item in entity.KeyOutcomeScore)
                        //    //{
                        //    //    if (result.KeyOutcomeScore.Any(a => a.KeyOutcomeId == item.KeyOutcomeId))
                        //    //    {
                        //    //        foreach (var item1 in result.KeyOutcomeScore)
                        //    //        {
                        //    //            if (item.KeyOutcomeId == item1.KeyOutcomeId)
                        //    //            {
                        //    //                if (item.EmployeeScore != null)
                        //    //                {
                        //    //                    result.KeyOutcomeScore.FirstOrDefault(x => x.KeyOutcomeId == item1.KeyOutcomeId).AppraisalScore = item.EmployeeScore;
                        //    //                }
                        //    //            }
                        //    //        }
                        //    //    }
                        //    //}
                        //    //result.AppraiseeFeedBack = entity.AppraiseeFeedBack;
                           
                        //    result.HodAccept.IsAccepted = true;
                        //    var average = result.AppraiseeCalculation.Average;
                        //    result.FinalCalculation.ScoreTotal = result.AppraiseeCalculation.ScoreTotal;
                        //    result.FinalCalculation.Average = average;
                        //    result.FinalCalculation.WeightContribution = (average * (Convert.ToDouble(result.KeyResultArea.Weight)) / 100);
                        //    var newAppraisalResult = result.HodApproval("");

                        //    var entityToUpdate = newAppraisalResult.ToBsonDocument();
                        //    var update = new BsonDocument("$set", entityToUpdate);
                        //    Collection.FindOneAndUpdate(filter, update, options: new FindOneAndUpdateOptions<AppraisalResult> { ReturnDocument = ReturnDocument.After });
                        //    msg = $"who is your HOD has completed your appraisal for the key result area {result.KeyResultArea.Name}, You are to accept or reject it";

                        //    email.ReceiverFullName = employee.FullName;
                        //    email.ReceiverEmailAddress = employee.Email;
                        //    email.HtmlContent = await sender.FormatEmail(result.KeyResultArea.HodDetails.Name, employee.FullName, msg, title, url);

                        //    if (email.HtmlContent == null)
                        //    {
                        //        email.HtmlContent = @$"<b>Dear {employee.FullName},</b> <br /> <br /> <p>{result.KeyResultArea.AppraiserDetails.Name} has successfully appraised you. Kindly login to the portal and View. <br /> Thank you.</p>";
                        //    }
                        //    emailDto.Add(email);
                        //}
                    }

                }
                catch (Exception)
                {
                    return false;
                }
                //finally
                //{
                //    var emailDtos = AppraisalResultExtension.FormatEmailForAppraisal(emailDto);

                //    if (emailDtos.Any())
                //    {
                //        emailDtos.ForEach(async e => await sender.SendToSingleEmployee(subject, e));
                //    }
                //}
            }

            return true;

        }

        public async Task<UpdateResult> EmployeeAcceptOrReject(int employeeId, ObjectId appraisalResultId, AcceptanceStatus status)
        {
            var filter = Builders<AppraisalResult>.Filter.Eq("Id", appraisalResultId);
            var appraisalResult = Collection.Find(filter).FirstOrDefault();

            if (appraisalResult != null)
            {
                if(appraisalResult.myId != employeeId)
                {
                    return null;
                }

                appraisalResult.EmployeeAccept = new AcceptanceStatus()
                {
                    IsAccepted = status.IsAccepted.Value
                };

                var newAppraisalResult = appraisalResult.CompleteAppraisal(status.Reason = "");
                var entityToUpdate = newAppraisalResult.ToBsonDocument();
                var update = new BsonDocument("$set", entityToUpdate);

                return await Collection.UpdateOneAsync(filter, update);
            }
            return null;
        }

        public async Task<bool> HodApprovalOrReject(OldEmployeeForViewDto Hod, OldEmployeeForViewDto employee, IEnumerable<HodApprovalDto> approvalDtos, ObjectId Cycle)
        {
            try
            {                
                foreach (var approvalDto in approvalDtos)
                {
                    var filter = Builders<AppraisalResult>.Filter.Where(a => a.Id == ObjectId.Parse(approvalDto.AppraisalResultId));
                    var appraisalResult = Collection.Find(filter).FirstOrDefault();            

                    if (appraisalResult != null)
                    {
                        if (appraisalResult.KeyResultArea.HodDetails.EmployeeId != Hod.EmployeeId)
                        {
                            continue;
                        }

                        appraisalResult.HodAccept = new AcceptanceStatus()
                        {
                            IsAccepted = approvalDto.Status
                        };

                        var average = appraisalResult.AppraiseeCalculation.Average;
                        appraisalResult.FinalCalculation.ScoreTotal = appraisalResult.AppraiseeCalculation.ScoreTotal;
                        appraisalResult.FinalCalculation.Average = average;
                        appraisalResult.FinalCalculation.WeightContribution = (average * (Convert.ToDouble(appraisalResult.KeyResultArea.Weight)) / 100);

                        var newAppraisalResult = appraisalResult.HodApproval("");
                        var entityToUpdate = newAppraisalResult.ToBsonDocument();
                        var update = new BsonDocument("$set", entityToUpdate);
                       
                        var res = await Collection.UpdateOneAsync(filter, update);
                    }

                }     
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        
        }

        public async Task<IEnumerable<AppraisalForApprovalDto>> GetEmployeesToAppraise(int employeeId, string appraisalConfigurationId, string appraisalCycleId, string whoAmI)
        {
            var year = DateTime.Now.Year;
            var pipeline = SupervisorEmployeeQuery.GetEmployeesToAppraise(employeeId, appraisalConfigurationId, appraisalCycleId);
            var lookupResult = KraCollection.Aggregate<AppraisalForApprovalDto>(pipeline);

            var finalResultToReturn = await GenerateDistinctArrayForEmployeeKRA(lookupResult);
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

        public async Task<bool?> HasPaticipatedInAppraisal(int employeeId)
        {
            var year = DateTime.Now.Year;
            var configuration = AppraisalConfigCollection.AsQueryable().FirstOrDefault(x=>x.Year == year);
            if(configuration != null)
            {
                var cycleId = configuration.Cycles.FirstOrDefault(x => x.isActive == true);
                if(cycleId != null)
                {
                     var result = Collection.AsQueryable().Any(x => x.myId == employeeId && x.AppraisalCycleId == cycleId.Id && x.AppraisalConfigId == configuration.Id);
                    return result;
    
                }
            }
            //this null is used to stop you from participating in the appraisal you are trying to access;
            return null;
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

            Func<KeyOutcome, bool> function = (x) => GetApplicableKeyOutcomes(x, configParam);
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
            var regex = new Regex("(continuously)|(yearly)|(annually)|(weekly)|(quaterly)|(continuous)|(ongoing)");
            var passedRegex = regex.IsMatch(keyOutcome.TimeLimit.ToLower());
            if (passedRegex) // not a date object
            {
                return true;
            }

            var validDate = DateTime.TryParse(keyOutcome.TimeLimit, out DateTime defaultParsedDate);
            if (validDate)
            {
                return defaultParsedDate <= cycle.StopDate;
            }
            else
            {
                var splitedTimelimit = keyOutcome.TimeLimit.Split('/');
                if (splitedTimelimit.Length < 3)
                {
                    return false;
                }
                var dateString = $"{splitedTimelimit[1]}/{splitedTimelimit[0]}/{splitedTimelimit[2]}";
                var isvalid = DateTime.TryParseExact(dateString, "MM/dd/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal, out parsedDate);

                if (isvalid)
                {
                    if (parsedDate <= cycle.StopDate)
                    {
                        return true;
                    }
                }
            }
            
            //unknown timelimit supplied so we return false
            return false;
        }


        public async Task<AppraisalConfig> GetAppraisalConfiguration(string configid)
        {
            var result = AppraisalConfigCollection.AsQueryable().FirstOrDefault(x => x.Id == ObjectId.Parse(configid));
            return await Task.FromResult(result);
        }

        public IEnumerable<KeyResultArea> GetOnlyApplicableKeyoutcomesForAppraisal(ObjectId kraId, int EmployeeId, IList<string> keyoutcomeIds)
        {
            var pipelineObj = AppraisalQueries.GetApplicableKeyOutcomes(kraId, EmployeeId, keyoutcomeIds);
            var result = KraCollection.Aggregate<KeyResultArea>(pipelineObj).ToList();
            return result;
        }

        public async Task<bool> UpdateKeyResultAreaForExistingResult(string cycleId)
        {
            try
            {
                var result = Collection.AsQueryable().Where(x => x.AppraisalCycleId == ObjectId.Parse(cycleId)).ToList();
                result.ForEach(async x => await UpdateAppraisalResult(x));

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return false;
            }         
        }

        public async Task UpdateAppraisalResult(AppraisalResult appraisalResult)
        {
            if(appraisalResult.KeyOutcomeScore.Count != appraisalResult.KeyResultArea.keyOutcomes.Count())
            {
                appraisalResult.KeyResultArea = GetOnlyApplicableKeyoutcomesForAppraisal(appraisalResult.KeyResultArea.Id,
                      appraisalResult.myId, appraisalResult.KeyOutcomeScore.Select(x => x.KeyOutcomeId.ToString()).ToList()).FirstOrDefault();

                var modifiedResult = appraisalResult.ToBsonDocument();
                var filter = Builders<AppraisalResult>.Filter.Where(x => x.Id == appraisalResult.Id);
                await Collection.ReplaceOneAsync(filter, appraisalResult);
            }
        }

        public async Task<bool> RestAppraisal(int empId, int appraiserId, ObjectId cycleId )
        {
            try
            {
                //var pipelineObj = AppraisalQueries.GetAppraisalResultForReset(empId, appraiserId, cycleId);
                //var result = Collection.Aggregate<AppraisalResult>(pipelineObj).ToList();

                var filter = Builders<AppraisalResult>.Filter.Where(x => x.myId == empId &&
                                                            x.KeyResultArea.HodDetails.EmployeeId == appraiserId
                                                            && x.AppraisalCycleId == cycleId);

                var appraisalResult = Collection.Find(filter).ToList();
                if (appraisalResult.Any())
                {
                    appraisalResult.ForEach(x => x.ResetForHod(Collection));
                }
                else
                {
                     filter = Builders<AppraisalResult>.Filter.Where(x => x.myId == empId &&
                                                            x.KeyResultArea.AppraiserDetails.EmployeeId == appraiserId
                                                            && x.AppraisalCycleId == cycleId);
                    appraisalResult = Collection.Find(filter).ToList();
                    appraisalResult.ForEach(x => x.ResetForAppraiser(Collection));
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ResetEmployeeAppraisal(int empId, ObjectId cycleId)
        {
            try
            {
                var filter = Builders<AppraisalResult>.Filter.Where(a => a.myId == empId && a.AppraisalCycleId == cycleId);

                var result = await Collection.DeleteManyAsync(filter);
                if (result.IsAcknowledged)
                {
                    await finalResultRepo.ResetEmployeeFinalAppraisal(empId, cycleId);
                }
                return result.IsAcknowledged;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public async Task SendOutEmail(OldEmployeeForViewDto employee, string subject, double finalResult)
        {
            SingleEmailDto emailDto = new SingleEmailDto()
            {
                ReceiverFullName = employee.FullName,
                ReceiverEmailAddress = employee.Email,
                HtmlContent = await sender.FormatEmailAppraisalScore(employee.FullName, finalResult.ToString()),
            };

            if (emailDto.HtmlContent == null)
            {
                emailDto.HtmlContent = @$"<b>Dear {employee.FullName},</b> <br /> <br /> <p>Your Appraisal Has been accepted. Kindly login to the portal and View. <br /> Thank you.</p>";
            }

            await sender.SendToSingleEmployee(subject, emailDto);

        }
    }
}
