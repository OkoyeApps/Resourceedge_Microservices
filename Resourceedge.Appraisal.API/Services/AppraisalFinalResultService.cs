using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
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

        public AppraisalFinalResultService(IDbContext _context)
        {
            Collection = _context.Database.GetCollection<FinalAppraisalResult>($"{nameof(FinalAppraisalResult)}s");
            AppraisalResultCollection = _context.Database.GetCollection<AppraisalResult>($"{nameof(AppraisalResult)}s");
            context = _context;

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
                        FinalResult = (appraisalResult.FirstOrDefault().IsAccepted != null) ? appraisalResult.Sum(x => x.FinalCalculation.WeightContribution) : 0
                    };

                    Collection.InsertOne(finalResult);
                }
                else
                {
                    oldFinalResult.EmployeeResult = appraisalResult.Sum(x => x.EmployeeCalculation.WeightContribution);
                    oldFinalResult.FinalResult = appraisalResult.Sum(x => x.FinalCalculation.WeightContribution);

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

        public IEnumerable<FinalAppraisalResult> GetAllResultByCycle(ObjectId cycleId)
        {
            var result = Collection.AsQueryable().Where(x => x.AppraisalCycleId == cycleId);

            return result;
        }

        public FinalAppraisalResult GetEmployeeResult(int empId, ObjectId cycleId)
        {
            return Collection.Find(x => x.AppraisalCycleId == cycleId && x.EmployeeId == empId).FirstOrDefault();
        }
    }
}
