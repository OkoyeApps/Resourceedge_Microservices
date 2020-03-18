using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public interface IKeyResultArea : IGenericRepository<KeyResultArea>
    {
        Task<KeyResultArea> QuerySingleByUserId(ObjectId id, string UserId);
        void AddKeyOutcomes(KeyResultArea entity);
        public void AddKeyOutcomes(IEnumerable<KeyResultArea> entity);
        public IEnumerable<KeyResultArea> GetPersonalkpis(string userId);
    }
}
