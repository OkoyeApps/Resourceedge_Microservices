using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Resourceedge.Appraisal.Domain.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly IMongoCollection<TEntity> Collection;

        public GenericRepository(IDbContext context)
        {
            Collection = context.Database.GetCollection<TEntity>($"{nameof(TEntity)}s");

        }

        public async Task<IEnumerable<TEntity>> Get(int? PageSize, int? PageNumber)
        {
            return await Collection.AsQueryable<TEntity>().Skip((PageNumber.Value -1) * PageSize.Value).ToListAsync();
        }

        public void Insert(TEntity entity)
        {
           

        }

        public void update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public TEntity QuerySingle(Func<TEntity, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> QuerySingle(Func<IEnumerable<TEntity>, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}
