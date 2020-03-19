using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public interface IKeyResultArea : IGenericRepository<KeyResultArea>
    {
        Task<KeyResultArea> QuerySingleByUserId(ObjectId id, string UserId);
        Task<KeyResultArea> QuerySingleUserKeyOutcome(ObjectId id, ObjectId outcomeId, string UserId);
        void AddKeyOutcomes(KeyResultArea entity);
        public void AddKeyOutcomes(IEnumerable<KeyResultArea> entity);
        public IEnumerable<KeyResultArea> GetPersonalkpis(string userId);
        public Task<KeyResultArea> Update(ObjectId Id, KeyResultAreaForUpdateMainDto entity);
        Task<long> UpdateKeyOutcome(ObjectId Id, ObjectId outcomeId, string UserId, KeyOutcomeForUpdateDto entity);

        Task<long> HodApproval(ObjectId keyResultAreaId, StatusForUpdateDto entity);
        Task<long> HodReject(ObjectId keyResultAreaId, StatusForUpdateDto entity);
        Task<long> EmpoyleeApproval(ObjectId keyResultAreaId, StatusForUpdateDto entity);
        Task<long> EmpoyleeReject(ObjectId keyResultAreaId, StatusForUpdateDto entity);
    }
}
