using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Services
{
    public class AppraisalFinalResultService : IAppraisalFinalResult
    {
        public readonly IMongoCollection<FinalAppraisalResult> Collection;
        public readonly IMongoCollection<AppraisalResult> AppraisalResultCollection;
        private readonly IDbContext context;
        private readonly ITeamRepository teamRepository;

        public AppraisalFinalResultService(IDbContext _context, ITeamRepository _teamRepo)
        {
            Collection = _context.Database.GetCollection<FinalAppraisalResult>($"{nameof(FinalAppraisalResult)}s");
            AppraisalResultCollection = _context.Database.GetCollection<AppraisalResult>($"{nameof(AppraisalResult)}s");
            context = _context;
            teamRepository = _teamRepo;

        }

        public void CalculateResult(int empId, ObjectId cycleId)
        {
            try
            {
                var appraisalResult = AppraisalResultCollection.AsQueryable().Where(x => x.myId == empId && x.AppraisalCycleId == cycleId);
                var filter = Builders<FinalAppraisalResult>.Filter.Where(x => x.EmployeeId == empId && x.AppraisalCycleId == cycleId);
                var oldFinalResult = Collection.Find(filter).FirstOrDefault();
                if(oldFinalResult == null)
                {
                    var finalResult = new FinalAppraisalResult()
                    {
                        AppraisalConfigId = appraisalResult.FirstOrDefault().AppraisalConfigId,
                        AppraisalCycleId = appraisalResult.FirstOrDefault().AppraisalCycleId,
                        EmployeeId = appraisalResult.FirstOrDefault().myId,
                        EmployeeResult = appraisalResult.Sum(x => x.EmployeeCalculation.WeightContribution),
                        AppraiseeResult = (appraisalResult.FirstOrDefault().IsAccepted != null) ? appraisalResult.Sum(x => x.AppraiseeCalculation.WeightContribution) : 0,
                        FinalResult = (appraisalResult.FirstOrDefault().IsCompleted != null) ? appraisalResult.Sum(x => x.FinalCalculation.WeightContribution) : 0,
                        Year = DateTime.Now.Year.ToString()
                    };

                    Collection.InsertOne(finalResult);
                }
                else
                {
                    oldFinalResult.EmployeeResult = (oldFinalResult.EmployeeResult != 0) ? oldFinalResult.EmployeeResult : appraisalResult.Sum(x => x.EmployeeCalculation.WeightContribution);
                    oldFinalResult.AppraiseeResult = (oldFinalResult.AppraiseeResult != 0) ? oldFinalResult.AppraiseeResult : appraisalResult.Sum(x => x.AppraiseeCalculation.WeightContribution);
                    oldFinalResult.FinalResult = (appraisalResult.FirstOrDefault().IsCompleted != null) ?  appraisalResult.Sum(x => x.FinalCalculation.WeightContribution) : 0;

                    var finalResult = oldFinalResult.ToBsonDocument();
                    var update = new BsonDocument("$set", finalResult);

                    Collection.UpdateOne(filter, update);
                }
           
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        public async Task<IEnumerable<FinalAppraisalResultForViewDto>> GetAllResultByCycle(ObjectId cycleId)
        {
            string year = DateTime.Now.Year.ToString();
            var match = new BsonDocument
            {
                {
                    "$match" ,
                    new BsonDocument
                    {
                        {$"AppraisalCycleId", cycleId },                       
                        {$"Year",  year}
                        
                    }
                }
            };

            var project = new BsonDocument
            {
                {
                    "$project", new BsonDocument{
                        { "EmployeeDetail", new BsonDocument
                            {
                                { "EmployeeId" , "$EmployeeId" }
                             }
                        },
                        {
                            "Result",new BsonDocument
                            {
                                {"FinalResult" , "$FinalResult" },
                                {"EmployeeResult", "$EmployeeResult" }
                            }
                        }
                    }
                }
            };


            var pipeline = new[] { match, project };
            var lookupResult = Collection.Aggregate<FinalAppraisalResultForViewDto>(pipeline);

            var result = lookupResult.ToList();
            var finalResultToReturn = new List<FinalAppraisalResultForViewDto>();
            if (result.Count > 0)
            {
                IEnumerable<string> IdsToSend = result.Select(x => x.EmployeeDetail.EmployeeId.ToString()).Distinct();
                foreach (var item in result)
                {
                    if (!finalResultToReturn.Any(x => x.EmployeeDetail.EmployeeId == item.EmployeeDetail.EmployeeId))
                    {
                        finalResultToReturn.Add(item);
                    }
                }

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

            //var result = Collection.AsQueryable().Where(x => x.AppraisalCycleId == cycleId);

            //return result;
        }

        public FinalAppraisalResult GetEmployeeResult(int empId, ObjectId cycleId)
        {
            return Collection.Find(x => x.AppraisalCycleId == cycleId && x.EmployeeId == empId).FirstOrDefault();
        }


    }
}
