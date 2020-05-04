using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Common.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Services
{
    public class CoreValueService : ICoreValue
    {
        public readonly IMongoCollection<CoreValuesKRA> Collection;
        public readonly IQueryable<CoreValuesKRA> QueryableCollection;
        private readonly ILogger<CoreValuesKRA> logger;

        public CoreValueService(IDbContext context, ILogger<CoreValuesKRA> _logger)
        {
            Collection = context.Database.GetCollection<CoreValuesKRA>($"{nameof(CoreValuesKRA)}s");
            QueryableCollection = Collection.AsQueryable<CoreValuesKRA>();
            logger = _logger;
        }

        public IEnumerable<CoreValuesKRA> Get(PaginationResourceParameter param)
        {
            return PagedList<CoreValuesKRA>.Create(QueryableCollection.OrderBy(c => c.Name), param.PageNumber, param.PageSize);
        }

        public PagedList<CoreValuesKRA> GetCoreValuesSearch(PaginationResourceParameter resourceParam)
        {
            var collection = QueryableCollection.Where(c => c.Name.Contains(resourceParam.SearchQuery, StringComparison.OrdinalIgnoreCase) || c.keyOutcomes.Any(x => x.Question == resourceParam.SearchQuery));

            return PagedList<CoreValuesKRA>.Create(collection, resourceParam.PageNumber, resourceParam.PageSize);
        }

        public CoreValuesKRA GetSingle(ObjectId Id)
        {
            return Collection.Find(Builders<CoreValuesKRA>.Filter.Eq("_Id", Id)).FirstOrDefault();
        }

        public void Insert(CoreValuesKRA coreValue)
        {
            Collection.InsertOne(coreValue);
        }

        public void Insert(IEnumerable<CoreValuesKRA> coreValues)
        {
            Collection.InsertMany(coreValues);
        }

        public async Task<CoreValuesKRA> UpdateCoreValue(ObjectId objId, CoreValueForUpdateDto updateDto)
        {
            if(updateDto != null)
            {
                var filter = Builders<CoreValuesKRA>.Filter.Where(r => r.Id == objId);
                var update = Builders<CoreValuesKRA>.Update.Set("Name", updateDto.Name);

                var result = await Collection.FindOneAndUpdateAsync(filter, update, options: new FindOneAndUpdateOptions<CoreValuesKRA> { ReturnDocument = ReturnDocument.After });

                return result;
            }

            return null;
        }

        public async Task<long> UpdateCoreValueKeyOutcome(ObjectId Id, ObjectId keyoutcomeId, KeyOutcomeForUpdateDto coreValue)
        {
            var filter = Builders<CoreValuesKRA>.Filter.Where(r => r.Id == Id);
            var bsonElement = coreValue.keyOutcomes.ToBsonDocument();

            var update = new BsonDocument("$set", bsonElement);

            var result = await Collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount;
        }
    }
}
;