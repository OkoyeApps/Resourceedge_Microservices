using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Appraisal.Domain.Queries;
using Resourceedge.Common.Archive;
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
        Task<(bool, string)> SubmitAppraisal(int empId, IEnumerable<AppraisalResultForCreationDto> entity);
        Task<UpdateResult> EmployeeAcceptOrReject(int employeeId, ObjectId appraisalResultId, AcceptanceStatus status);
        Task<bool> HodApprovalOrReject(OldEmployeeForViewDto Hod, OldEmployeeForViewDto employee, IEnumerable<HodApprovalDto> approvalDto, ObjectId Cycle);
        Task<IEnumerable<AppraisalForApprovalDto>> GetEmployeesToAppraise(int employeeId, string appraisalConfigurationId, string appraisalCycleId, string whoami);
        Task<bool?> HasPaticipatedInAppraisal(int employeeId);
        Task<bool> CheckAppraisalConfigurationDetails(AppraisalQueryParam model);
        Task<bool> CheckMultipleAppraisalConfigurationDetails(IEnumerable<AppraisalQueryParam> model);
        Task<bool> AppraiseEmployee(int empId, IEnumerable<AppraisalResultForCreationDto> entities);
        IEnumerable<KeyResultArea> GetAcceptedKRAForAppraisal(int userId, AppraisalCycle configParam, string resultId = null);
        Task<AppraisalConfig> GetAppraisalConfiguration(string configid);
        IEnumerable<KeyResultArea> GetOnlyApplicableKeyoutcomesForAppraisal(ObjectId kraId, int EmployeeId, IList<string> keyoutcomeIds);
        Task<bool> UpdateKeyResultAreaForExistingResult(string cycleId);
        Task UpdateAppraisalResult(AppraisalResult appraisalResult);
        Task<bool> RestAppraisal(int empId, int appraiserId, ObjectId cycleId);
        Task<bool> ResetEmployeeAppraisal(int empId, ObjectId cycleId);
        Task SendOutEmail(OldEmployeeForViewDto employee, string subject, double finalResult);
    }
}
