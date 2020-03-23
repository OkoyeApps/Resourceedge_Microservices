using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Resourceedge.Appraisal.API.Services
{
    public class AppraisalResultService : IAppraisalResult
    {
        public readonly IMongoCollection<AppraisalResult> Collection;
        private readonly IMapper mapper;

        public AppraisalResultService(IDbContext context, IMapper _mapper)
        {
            Collection = context.Database.GetCollection<AppraisalResult>($"{nameof(AppraisalResult)}s");
            mapper = _mapper;
        }

        public IEnumerable<AppraisalResult> Get(ObjectId AppraisalConfigId, ObjectId CycleId, int? EmployeeId)
        {
            var result = Collection.AsQueryable().Where(a => a.myId == EmployeeId && a.AppraisalConfigId == AppraisalConfigId && a.AppraisalCycleId == CycleId);
            return result.ToList();
        }

        public void InsertResult(AppraisalResult entity)
        {
            Collection.InsertOne(entity);
        }

        public void SubmitAppraisal(AppraisalResultForCreationDto entity)
        {

            var filter = Builders<AppraisalResult>.Filter.Where(a => a.myId == entity.myId && a.AppraisalConfigId == entity.AppraisalConfigId && a.AppraisalCycleId == entity.AppraisalCycleId && a.KeyResultAreaId == entity.KeyResultAreaId);
            var result = Collection.Find(a => a.myId == entity.myId && a.AppraisalConfigId == entity.AppraisalConfigId && a.AppraisalCycleId == entity.AppraisalCycleId && a.KeyResultAreaId == entity.KeyResultAreaId).FirstOrDefault();

            if (entity.whoami == null)
            {
                var myAppraisal = mapper.Map<AppraisalResult>(entity);
                this.InsertResult(myAppraisal);
            }
            else if (entity.whoami == "APPRAISAL")
            {
                foreach (var item in entity.KeyOutcomeScore)
                {
                    if (result.KeyOutcomeScore.Any(a => a.KeyOutcomeId == item.KeyOutcomeId))
                    {
                        foreach (var item1 in result.KeyOutcomeScore)
                        {
                            if (item.KeyOutcomeId == item1.KeyOutcomeId)
                            {
                                result.KeyOutcomeScore.FirstOrDefault( x => x.KeyOutcomeId == item1.KeyOutcomeId).AppraisalScore = item.EmployeeScore;
                            }
                        }
                    }
                }
                var entityToUpdate = result.ToBsonDocument(); 
                var update = new BsonDocument("$set", entityToUpdate);
                Collection.FindOneAndUpdate(filter, update, options: new FindOneAndUpdateOptions<AppraisalResult> { ReturnDocument = ReturnDocument.After }) ;
            }
            else if (entity.whoami == "HOD")
            {
                foreach (var item in entity.KeyOutcomeScore)
                {
                    if (result.KeyOutcomeScore.Any(a => a.KeyOutcomeId == item.KeyOutcomeId))
                    {
                        foreach (var item1 in result.KeyOutcomeScore)
                        {
                            if (item.KeyOutcomeId == item1.KeyOutcomeId)
                            {
                                result.KeyOutcomeScore.FirstOrDefault(x => x.KeyOutcomeId == item1.KeyOutcomeId).HodScore = item.EmployeeScore;
                            }
                        }
                    }
                }
                var entityToUpdate = result.ToBsonDocument();
                var update = new BsonDocument("$set", entityToUpdate);
                Collection.FindOneAndUpdate(filter, update, options: new FindOneAndUpdateOptions<AppraisalResult> { ReturnDocument = ReturnDocument.After });
            }
        }
    }
}
