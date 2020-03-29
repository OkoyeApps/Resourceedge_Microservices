using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resourceedge.Appraisal.API.Services
{
    public class InitializerService
    {
        public static void Seed(IApplicationBuilder service)
        {
            var dbContext = service.ApplicationServices.GetRequiredService(typeof(IDbContext)) as IDbContext;
            if (dbContext != null)
            {
                var collection = dbContext.Database.GetCollection<KeyResultArea>($"{nameof(KeyResultArea)}s");
                if (!collection.AsQueryable().Any())
                {

                    var dataToAdd = new List<KeyResultArea>()
                    {
                        new KeyResultArea
                        {
                            UserId = Guid.NewGuid().ToString(),
                             EmployeeId = 1,
                            AppraiserDetails = new NameEmail { Name = "Emmanuel", EmployeeId = 1, Email = "appraisal@test.com" },
                            HodDetails = new NameEmail { Name = "EmmanuelHod", EmployeeId = 4, Email = "Hod@test.com" },
                            keyOutcomes =
                            {
                                new KeyOutcome{ Question = "Test question 1", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString() },
                                new KeyOutcome{ Question = "Test question 2", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString()},
                                new KeyOutcome{ Question = "Test question 3", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString()},
                            },
                            Weight = 50,
                            Approved = true,
                            Name = "School Manager",
                            Status = new ApprovalStatus  { Employee =true, Hod = true, IsAccepted = true }
                        },
                        new KeyResultArea
                        {
                            UserId = Guid.NewGuid().ToString(),
                            EmployeeId = 1,
                            AppraiserDetails = new NameEmail { Name = "Test", EmployeeId = 1, Email = "test@test.com" },
                            HodDetails = new NameEmail { Name = "TestlHod", EmployeeId = 1, Email = "test@test.com" },
                            keyOutcomes =
                            {
                                new KeyOutcome{ Question = "Test question 4", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString()},
                                new KeyOutcome{ Question = "Test question 5", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString()},
                                new KeyOutcome{ Question = "Test question 6", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString()},
                            },
                            Weight = 50,
                            Approved = true,
                            Name = "School Manager",
                            Status = new ApprovalStatus { Employee =true, Hod = false, IsAccepted = true }
                        }
                    };

                    collection.InsertMany(dataToAdd);

                }

                var coreValueCollection = dbContext.Database.GetCollection<CoreValuesKRA>($"{nameof(CoreValuesKRA)}s");
                if (!coreValueCollection.AsQueryable().Any())
                {
                    var data = new List<CoreValuesKRA>()
                    {
                        new CoreValuesKRA()
                        {
                            Name = "Tenece Core Value",
                            Description = "Kindly select this if you are in tenece",
                            keyOutcomes =
                            {
                                new KeyOutcome(){Question = "Candour", TimeLimit = "Annual"},
                                new KeyOutcome(){Question = "Tenecity", TimeLimit = "Annual"},
                            },
                            Approved = true,
                            IsActive = true
                        },
                        new CoreValuesKRA()
                        {
                                 Name = "Genesys Core Value",
                            Description = "Kindly select this if you are in genesys",
                            keyOutcomes =
                            {
                                new KeyOutcome(){Question = "Candour", TimeLimit = "Annual"},
                                new KeyOutcome(){Question = "Tenecity", TimeLimit = "Annual"},
                            },
                            Approved = true,
                            IsActive = true
                        }

                    };

                    coreValueCollection.InsertMany(data);
                }

                //var AppraisalCollection = dbContext.Database.GetCollection<AppraisalResult>($"{nameof(AppraisalResult)}s");
                //if (!AppraisalCollection.AsQueryable().Any())
                //{
                //    ObjectId objId = new ObjectId("5e78a4474c0bf888746215e8");
                //    var result = new List<AppraisalResult>()
                //    {
                //        new AppraisalResult()
                //        {
                //            Id = ObjectId.GenerateNewId(),
                //             myId = 1,
                //            AppraisalConfigId = ObjectId.GenerateNewId(),
                //            AppraisalCycleId = ObjectId.GenerateNewId(),
                //            KeyResultArea = collection.Find(a => a.Id == objId).FirstOrDefault(),
                //            KeyOutcomeScore =
                //            {
                //                new AppraisalKeyOutcome()
                //                {
                //                    KeyOutcomeId = ObjectId.GenerateNewId(),
                //                    EmployeeScore = 4,
                //                    AppraisalScore = 3,
                //                    HodScore = 3
                //                },
                //                new AppraisalKeyOutcome(){ KeyOutcomeId = ObjectId.GenerateNewId(),
                //                EmployeeScore = 4,
                //                AppraisalScore = 3,
                //                HodScore = 3
                //                }
                //            },
                //            AppraiseeFeedBack = new FeedBack()
                //            {
                //                Comment = "Need to pay attention to details", Recommendation = "Training on personal development"
                //            },
                //            EmployeeAccept = new AcceptanceStatus()
                //            {
                //                IsAccepted = true,
                //                Reason = ""
                //            },
                //            HodAccept = new AcceptanceStatus()
                //            {
                //                IsAccepted = true,
                //                Reason = ""
                //            },
                //            IsAccepted = true,
                //            IsCompleted = true,
                //            CurrentSupervisor = "HOD"
                //        },
                //        new AppraisalResult()
                //        {
                //            Id = ObjectId.GenerateNewId(),
                //             myId = 1,
                //            AppraisalConfigId= ObjectId.GenerateNewId(),
                //            AppraisalCycleId=ObjectId.GenerateNewId(),
                //            KeyResultArea = collection.Find(a => a.Id == objId).FirstOrDefault(),
                //            KeyOutcomeScore =
                //            {
                //                new AppraisalKeyOutcome()
                //                { KeyOutcomeId = ObjectId.GenerateNewId(),
                //                    EmployeeScore = 4,
                //                    AppraisalScore = 3,
                //                    HodScore = 3
                //                },
                //                new AppraisalKeyOutcome(){ KeyOutcomeId = ObjectId.GenerateNewId(),
                //                EmployeeScore = 4,
                //                AppraisalScore = 3,
                //                HodScore = 3
                //                }
                //            },
                //            AppraiseeFeedBack = new FeedBack()
                //            {
                //                Comment = "Impressive Growth", Recommendation = "Training on Agile Software Development"
                //            },
                //            EmployeeAccept = new AcceptanceStatus()
                //            {
                //                IsAccepted = true,
                //                Reason = ""
                //            },
                //            HodAccept = new AcceptanceStatus()
                //            {
                //                IsAccepted = true,
                //                Reason = ""
                //            },
                //            IsAccepted = true,
                //            IsCompleted = true,
                //            CurrentSupervisor = "HOD"
                //        }
                //    };

                //    AppraisalCollection.InsertMany(result);
                //}
            }
        }
    }
}
