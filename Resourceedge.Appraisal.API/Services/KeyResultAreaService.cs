using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
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
        private readonly ILogger<KeyResultArea> logger;

        public KeyResultAreaService(IDbContext context, ILogger<KeyResultArea> _logger)
        {
            Collection = context.Database.GetCollection<KeyResultArea>($"{nameof(KeyResultArea)}s");
            QueryableCollection = Collection.AsQueryable<KeyResultArea>();
            logger = _logger;
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

        public async Task<KeyResultArea> QuerySingle(ObjectId Id)
        {
            var filter = Builders<KeyResultArea>.Filter.Where(a => a.Id == Id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public IEnumerable<KeyResultArea> QuerySingle(Func<IEnumerable<KeyResultArea>, bool> func)
        {
            throw new NotImplementedException();
        }

        public async Task<KeyResultArea> Update(ObjectId Id, KeyResultAreaForUpdateMainDto entity)
        {
            var filter = Builders<KeyResultArea>.Filter.Where(r => r.Id == Id);        
            var aa = entity.ToBsonDocument();
            var update = new BsonDocument("$set", aa);
            Collection.UpdateOne(filter, update);

            return null;
        }

        public async void Delete(ObjectId id)
        {
            if (id != null)
            {
                await Collection.FindOneAndDeleteAsync(a => a.Id == id);
            }
        }

        public async void Delete(KeyResultArea entity)
        {
           await Collection.FindOneAndDeleteAsync(Builders<KeyResultArea>.Filter.Where(r => r == entity));
        }

        public async Task<KeyResultArea> QuerySingleByUserId(ObjectId id, string UserId)
        {
            if(id != null && UserId != null)
            {
                var filter = Builders<KeyResultArea>.Filter.Where(r => r.Id == id && r.UserId == UserId);
               var result  = await Collection.FindAsync(filter);

                return result.FirstOrDefault();
            }
            return null;        
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

        public IEnumerable<KeyResultArea> GetPersonalkpis(string userId)
        {
            return  QueryableCollection.Where(x => x.UserId == userId).ToList();
        }

        public Task<KeyResultArea> Update(ObjectId Id, KeyResultArea entity)
        {
            throw new NotImplementedException();
        }

        public async Task<KeyResultArea> QuerySingleUserKeyOutcome(ObjectId id, ObjectId outcomeId, string UserId)
        {
            if (id != null && UserId != null)
            {
                var filter = Builders<KeyResultArea>.Filter.Where(r => r.Id == id && r.UserId == UserId && r.keyOutcomes.Any(a => a.Id == outcomeId));
                var result = await Collection.FindAsync(filter);

                return result.FirstOrDefault();
            }
            return null;
        }

        public async Task<long> UpdateKeyOutcome(ObjectId Id, ObjectId outcomeId, string UserId, KeyOutcomeForUpdateDto entity)
        {
            entity.keyOutcomes.Id = outcomeId;
            var filter = Builders<KeyResultArea>.Filter.Where(r => r.Id == Id && r.UserId == UserId && r.keyOutcomes.Any(a => a.Id == outcomeId));
            //var update = new BsonDocument("$set", entity.ToBsonDocument());
            var bsonElement = entity.keyOutcomes.ToBsonDocument();

            var update = Builders<KeyResultArea>.Update.Set("keyOutcomes.$", bsonElement);

            var result = await Collection.UpdateOneAsync(filter,update);

            return result.ModifiedCount;
        }

        public async Task<long> HodApproval(ObjectId keyResultAreaId, StatusForUpdateDto entity)
        {
            try
            {
                var filter = Builders<KeyResultArea>.Filter.Where(r => r.keyOutcomes.Any(a => a.Id == keyResultAreaId));
                var update = Builders<KeyResultArea>.Update.Set("keyOutcomes.Hod", entity.Hod);
                var result = await Collection.UpdateOneAsync(filter, update);
             
                return result.MatchedCount;              
            }
            catch (Exception ex)
            {
                logger.LogError("update of appraisal configuration failed", ex);
                return 0;
            }
        }

        public async Task<long> EmpoyleeApproval(ObjectId keyResultAreaId, StatusForUpdateDto entity)
        {
            try
            {
                var filter = Builders<KeyResultArea>.Filter.Where(r => r.keyOutcomes.Any(a => a.Id == keyResultAreaId));
                var update = Builders<KeyResultArea>.Update.Set("keyOutcomes.Employee", entity.Employee);
                var result = await Collection.UpdateOneAsync(filter, update);

                return result.MatchedCount;
            }
            catch (Exception ex)
            {
                logger.LogError("update of appraisal configuration failed", ex);
                return 0;
            }
        }

        public Task<long> EmpoyleeReject(ObjectId keyResultAreaId, StatusForUpdateDto entity)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<KeyResultArea> GetKeyResultAreasForAppraiser(int appraiserId, int employeeId)
        {
            var result = QueryableCollection.Where(x => x.HodDetails.EmployeeId == appraiserId || x.AppraiserDetails.EmployeeId == appraiserId && x.EmployeeId == employeeId).ToList();
            return result;
        }
    }
}
