using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class 
    {
        //public IMongoCollection<TEntity> Collection { get; }
        //public IQueryable<TEntity> QueryableCollection   { get; }

        Task<IEnumerable<TEntity>> Get(int? PageSize, int? PageNumber);
        void Insert(TEntity entity);
        void Delete(ObjectId id);
        void Delete(TEntity entity);
        Task<TEntity> Update(ObjectId Id, TEntity entity);
        Task<TEntity> QuerySingle(ObjectId id); 
        IEnumerable<TEntity> QuerySingle(Func<IEnumerable<TEntity>, bool> func); 
    }
}
