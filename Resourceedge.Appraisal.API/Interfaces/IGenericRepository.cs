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
        Task<TEntity> Update(ObjectId Id, TEntity entity);
        //TEntity QuerySingle(Func<TEntity> func);
        IEnumerable<TEntity> QuerySingle(Func<IEnumerable<TEntity>, bool> func);
    }
}
