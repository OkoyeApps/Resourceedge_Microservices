using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Services
{
    public class KeyResultAreaService : IKeyResultArea
    {
        public readonly IMongoCollection<KeyResultArea> Collection;
        public readonly IQueryable<KeyResultArea> QueryableCollection;

        public KeyResultAreaService(IDbContext context)
        {
            Collection = context.Database.GetCollection<KeyResultArea>($"{nameof(KeyResultArea)}s");
            QueryableCollection = Collection.AsQueryable<KeyResultArea>();
        }


        public async Task<IEnumerable<KeyResultArea>> Get(int? PageSize, int? PageNumber)
        {
            return await Collection.AsQueryable().Skip((PageNumber.Value - 1) * PageSize.Value).Take(PageSize.Value).ToListAsync();
        }

        public void Insert(KeyResultArea entity)
        {
            if (entity != null)
            {
                Collection.InsertOne(entity);
            }
        }

        public KeyResultArea QuerySingle(Func<KeyResultArea, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyResultArea> QuerySingle(Func<IEnumerable<KeyResultArea>, bool> func)
        {
            throw new NotImplementedException();
        }

        public async Task<KeyResultArea> Update(ObjectId Id, KeyResultArea entity)
        {
            var result = await Collection.FindOneAndUpdateAsync(Builders<KeyResultArea>.Filter.Where(r => r.Id == Id), Builders<KeyResultArea>.Update.Set(r => r, entity),
                options: new FindOneAndUpdateOptions<KeyResultArea>
                {
                    ReturnDocument = ReturnDocument.After
                });

            return result;
        }

        public async void Delete(ObjectId id)
        {
            if (id != null)
            {
                await Collection.FindOneAndDeleteAsync(a => a.Id == id);
            }
        }

        public void AddKeyOutcomes(IEnumerable<KeyResultArea> entity)
        {
            Collection.InsertMany(entity);
            return;
        }

        public void AddKeyOutcomes(KeyResultArea entity)
        {
            Collection.InsertOne(entity);
        }

        public IEnumerable<KeyResultArea> GetPersonalkpis(int employeeId)
        {
            return  QueryableCollection.Where(x => x.EmployeeId == employeeId).ToList();
        }

        public IEnumerable<KeyResultArea> GetKeyResultAreasForAppraiser(int appraiserId, int employeeId)
        {
            var result = QueryableCollection.Where(x => x.HodDetails.EmployeeId == appraiserId || x.AppraiserDetails.EmployeeId == appraiserId && x.EmployeeId == employeeId).ToList();
            return result;
        }
    }
}
