using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public interface IAppraisalFinalResult
    {
        void CalculateResult(int empId, ObjectId cycleId);
        Task<IEnumerable<FinalAppraisalResultForViewDto>> GetAllResultByCycle(ObjectId cycleId);
        FinalAppraisalResult GetEmployeeResult(int empId, ObjectId cycleId);
        Task<IEnumerable<FinalAppraisalResultForViewDto>> GetAppraisalResultByGroup(string group, int pageNumber, int pageSize, ObjectId cycleId);
        Task<IEnumerable<OrgaizationandCount>> GetOrgaization(ObjectId CycleId);
    }
}
