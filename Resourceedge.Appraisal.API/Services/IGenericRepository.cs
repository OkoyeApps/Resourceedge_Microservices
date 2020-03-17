using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Services
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get(int? PageSize, int? PageNumber);
        TEntity GetById(ObjectId id);
        void Insert(TEntity entity);
        void Delete(ObjectId id);
        void update(TEntity entity);
        TEntity GetByUserId(string userId);
    }
}
