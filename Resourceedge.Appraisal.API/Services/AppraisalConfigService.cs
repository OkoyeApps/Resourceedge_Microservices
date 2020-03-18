using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.API.ResourceParamters;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Services
{
    public class AppraisalConfigService : IAppraisalConfig
    {
        private readonly IMongoCollection<AppraisalConfig> Collection;
        public readonly IQueryable<AppraisalConfig> QueryableCollection;
        private readonly ILogger logger;

        public AppraisalConfigService(IDbContext context, ILogger<AppraisalConfig> _logger)
        {
            Collection = context?.Database.GetCollection<AppraisalConfig>($"{nameof(AppraisalConfig)}s") ?? throw new ArgumentNullException(nameof(context));
            QueryableCollection = Collection.AsQueryable<AppraisalConfig>();
            this.logger = _logger;
        }

        public async Task<bool> Delete(ObjectId id)
        {
            var result = await Collection.DeleteOneAsync(Builders<AppraisalConfig>.Filter.Eq("Id", id));
            return result.DeletedCount > 0 ? true : false;
        }

        public async Task<IEnumerable<AppraisalConfig>> Get(AppraisalConfigParameters param)
        {
            if (param.Year != 0)
            {
                var result = await Collection.FindAsync(x => x.Year == param.Year);
                return result.ToList();
            }
            return await Collection.AsQueryable().ToListAsync();
        }

        public bool Insert(AppraisalConfig entity)
        {
            try
            {
                Collection.InsertOne(entity);
                return true; ;
            }
            catch (Exception ex)
            {
                logger.LogError("Insert of appraisal configuration failed", ex);
                Console.WriteLine("failed to update  appraisal", ex.Message.ToString());
                return false;
            }
        }

        public async Task<AppraisalConfig> Update(ObjectId Id, AppraisalCycle entity)
        {
            try
            {
                var filter = Builders<AppraisalConfig>.Filter.Eq("Id", Id);
                var update = Builders<AppraisalConfig>.Update.Set("Cycles", entity);
                var result = await Collection.FindOneAndUpdateAsync(filter, update, options: new FindOneAndUpdateOptions<AppraisalConfig, AppraisalConfig> { ReturnDocument = ReturnDocument.After });
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError("update of appraisal configuration failed", ex);
                Console.WriteLine("failed to update  appraisal", ex.Message.ToString());
                return null;
            }
        }

     
    }
}
