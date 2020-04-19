using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Appraisal.Domain.Queries;
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

        Task<bool> SubmitAppraisal(int empId, IEnumerable<AppraisalResultForCreationDto> entity);
        Task<UpdateResult> EmployeeAcceptOrReject(ObjectId appraisalResultId, AcceptanceStatus status);

        Task<UpdateResult> HodApprovalOrReject(ObjectId appraisalResultId, AcceptanceStatus status);
        Task<IEnumerable<AppraisalForApprovalDto>> GetEmployeesToAppraise(int employeeId, string appraisalConfigurationId, string appraisalCycleId, string whoami);

        Task<bool> HasPaticipatedInAppraisal(int employeeId);

        Task<bool> CheckAppraisalConfigurationDetails(AppraisalQueryParam model);
        Task<bool> CheckMultipleAppraisalConfigurationDetails(IEnumerable<AppraisalQueryParam> model);
        Task<bool> AppraiseEmployee(int empId, IEnumerable<AppraisalResultForCreationDto> entities);

    }
}
