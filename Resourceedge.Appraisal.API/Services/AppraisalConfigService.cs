using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.API.ResourceParamters;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
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
        private readonly ILogger<AppraisalConfigService> logger;

        public AppraisalConfigService(IDbContext context, ILogger<AppraisalConfigService> _logger)
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
                return true; 
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

        public AppraisalCycleForAppraisal GetActiveCycle()
        {
            return Collection.Find(c => c.Year == DateTime.Now.Year).ToList()
                .Select( x => new AppraisalCycleForAppraisal { 
                    ConfigId = x.Id,
                    Cycle = x.Cycles
                    .Where(y => y.isActive == true)
                    .FirstOrDefault() 
                }).FirstOrDefault();
        }

        public bool ActivateCycle(string cycleId)
        {
            var filter = Builders<AppraisalConfig>.Filter.Where(c => c.Year == DateTime.Now.Year);
            var appraisalConfig = Collection.Find(filter).First();

            appraisalConfig.Cycles.ForEach(c => { 

                if(c.Id == ObjectId.Parse(cycleId))
                {
                    c.isActive = true;
                }
                else
                {
                    c.isActive = false;
                }
                
            });
            return true;
        }

        public bool DeactivateCycle(ObjectId configId, AppraisalCycle cycle)
        {
            try
            {
                var filter = Builders<AppraisalConfig>.Filter.Eq("Id", configId);
                var config = Collection.Find(filter).First();
                if (config != null)
                {
                    var activeCycle = config.Cycles.First(c => c.Id == cycle.Id);
                    activeCycle.isActive = false;

                    var update = config.ToBsonDocument();
                    Collection.UpdateOne(filter, update);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }

        public bool ActivateCycle(AppraisalConfig appraisalConfig, ObjectId cycleId)
        {
            try
            {
                var filter = Builders<AppraisalConfig>.Filter.Eq("Id", appraisalConfig.Id);
                if (appraisalConfig != null)
                {
                    var activeCycle = appraisalConfig.Cycles.First(c => c.Id == cycleId);
                    activeCycle.isActive = true;

                    var update = appraisalConfig.ToBsonDocument();
                    Collection.UpdateOne(filter, update);

                    return true;
                }

                return false;

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
