using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public interface IAppraisalResult
    {
        IEnumerable<AppraisalResult> Get(ObjectId AppraisalConfigId, ObjectId CycleId, int? EmployeeId);

        void InsertResult(AppraisalResult entity);

        void SubmitAppraisal(IEnumerable<AppraisalResultForCreationDto> entity);

        Task<UpdateResult> EmployeeAcceptOrReject(ObjectId appraisalResultId, AcceptanceStatus status);

        Task<UpdateResult> HodApprovalOrReject(ObjectId appraisalResultId, AcceptanceStatus status);
        Task<IEnumerable<AppraisalForApprovalDto>> GetEmployeesToAppraise(int employeeId, string whoami);

        Task<bool> HasPaticipatedInAppraisal(int employeeId);
    }
}
