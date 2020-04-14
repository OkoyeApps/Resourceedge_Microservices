using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public interface IAppraisalFinalResult
    {
        void CalculateResult(int empId, ObjectId cycleId);
        IEnumerable<FinalAppraisalResult> GetAllResultByCycle(ObjectId cycleId);
        FinalAppraisalResult GetEmployeeResult(int empId, ObjectId cycleId);


    }
}
