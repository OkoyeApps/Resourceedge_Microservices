using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Services
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
       Task<IEnumerable<TEntity>> Get(int? PageSize, int? PageNumber);
        void Insert(TEntity entity);
        void Delete(ObjectId id);
        void update(TEntity entity);
        TEntity QuerySingle(Func<TEntity, bool> func); 
        IEnumerable<TEntity> QuerySingle(Func<IEnumerable<TEntity>, bool> func); 
    }
}
