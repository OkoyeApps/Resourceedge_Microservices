using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Common.Archive;
using Resourceedge.Common.Util;
using Resourceedge.Email.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public interface IKeyResultArea : IGenericRepository<KeyResultArea>
    {
        Task<KeyResultArea> QuerySingleByUserId(ObjectId id, int UserId);
        Task<KeyResultArea> QuerySingleUserKeyOutcome(ObjectId id, ObjectId outcomeId, int empId);
        void AddKeyOutcomes(KeyResultArea entity);
         Task<bool> AddKeyOutcomes(IEnumerable<KeyResultArea> entity);
        public IEnumerable<KeyResultArea> GetPersonalkpis(int empId, string resultArea = null);
        public KeyResultArea Update(ObjectId Id, KeyResultAreaForUpdateMainDto entity);
        Task<long> UpdateKeyOutcome(ObjectId Id, ObjectId outcomeId, int empId, KeyOutcomeForUpdateDto entity);
        Task<KeyResultArea> HodApproval(int empId, int memberId, ObjectId keyResultAreaId, string whoami, StatusForUpdateDto entity);
        Task<KeyResultArea> EmployeeApproval(int empId, StatusForUpdateDto entity);
        IEnumerable<KeyResultArea> GetKeyResultAreasForAppraiser(int appraiserId, int employeeId);
        void SendApprovalNotification(IEnumerable<KeyResultArea> keyAreas);
        Task<OldEmployeeForViewDto> GetEmployee(int empId);
        bool HasUploadedEpa(int employeeId);

    }
}
