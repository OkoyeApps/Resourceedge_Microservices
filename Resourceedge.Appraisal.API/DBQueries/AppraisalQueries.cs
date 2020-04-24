using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.DBQueries
{
    public static class AppraisalQueries
    {
        public static BsonDocument[] GetApplicableKeyOutcomes(ObjectId kraId, int EmployeeId, IList<string> KeyoutcomeIds)
        {
            var arrayOfIds =new List<ObjectId>();
            var inputArray = new BsonArray(arrayOfIds);

            foreach (var item in KeyoutcomeIds)
            {
                arrayOfIds.Add(ObjectId.Parse(item));
            }
             
            var match = new BsonDocument
            {
                {
                    "$match", new BsonDocument
                    {
                        {
                            "EmployeeId", new BsonDocument {
                                {"$eq", EmployeeId }
                            }
                        },
                        {
                            "_id", new BsonDocument
                            {
                                {"$eq",  kraId}
                            } 
                        }
                    }
                }
            };

            var filter = new BsonDocument
            {
                {
                    "$project", new BsonDocument
                    {
                        {
                            "keyOutcomes",  new BsonDocument
                            {
                                {
                                    "$filter", new BsonDocument
                                    {
                                        {"input", "$keyOutcomes" },
                                        {"as", "item" },
                                            {"cond", new BsonDocument {
                                                {"$in", new BsonArray(new dynamic[]{ "$$item._id", inputArray }) }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        {"EmployeeId", 1 },
                        {"Name", 1 },
                        {"Weight", 1 },
                        {"HodDetails", 1 },
                        {"AppraiserDetails", 1 },
                        {"Approved", 1 },
                        {"Year", 1 },
                        {"IsActive", 1 },
                        {"Status", 1 }
                    }
                }
            };
            return new[] { match , filter};
        }
    }
}
