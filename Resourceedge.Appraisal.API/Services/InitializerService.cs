using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Common.Models;
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

                    //var dataToAdd = new List<KeyResultArea>()
                    //{
                    //    new KeyResultArea
                    //    {
                    //        UserId = Guid.NewGuid().ToString(),
                    //         EmployeeId = 1,
                    //        AppraiserDetails = new NameEmail { Name = "Emmanuel", EmployeeId = 1, Email = "appraisal@test.com" },
                    //        HodDetails = new NameEmail { Name = "EmmanuelHod", EmployeeId = 4, Email = "Hod@test.com" },
                    //        keyOutcomes =
                    //        {
                    //            new KeyOutcome{ Question = "Test question 1", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString() },
                    //            new KeyOutcome{ Question = "Test question 2", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString()},
                    //            new KeyOutcome{ Question = "Test question 3", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString()},
                    //        },
                    //        Weight = 50,
                    //        Approved = true,
                    //        Name = "School Manager",
                    //        Status = new ApprovalStatus  { Employee =true, Hod = true, IsAccepted = true }
                    //    },
                    //    new KeyResultArea
                    //    {
                    //        UserId = Guid.NewGuid().ToString(),
                    //        EmployeeId = 1,
                    //        AppraiserDetails = new NameEmail { Name = "Test", EmployeeId = 1, Email = "test@test.com" },
                    //        HodDetails = new NameEmail { Name = "TestlHod", EmployeeId = 1, Email = "test@test.com" },
                    //        keyOutcomes =
                    //        {
                    //            new KeyOutcome{ Question = "Test question 4", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString()},
                    //            new KeyOutcome{ Question = "Test question 5", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString()},
                    //            new KeyOutcome{ Question = "Test question 6", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString()},
                    //        },
                    //        Weight = 50,
                    //        Approved = true,
                    //        Name = "School Manager",
                    //        Status = new ApprovalStatus { Employee =true, Hod = false, IsAccepted = true }
                    //    }
                    //};

                    //collection.InsertMany(dataToAdd);

                }

                var coreValueCollection = dbContext.Database.GetCollection<CoreValuesKRA>($"{nameof(CoreValuesKRA)}s");
                if (!coreValueCollection.AsQueryable().Any())
                {
                    var data = new List<CoreValuesKRA>()
                    {
                        new CoreValuesKRA()
                        {
                            Name = "Tenece Core Value",
                            Description = "5% of total appraisal score, Kindly select this if you are in tenece",
                            Weight=5,
                            keyOutcomes =
                            {
                                new KeyOutcome(){Question = "Innovation and Creativity - Designs/Changes process/work to improve/increase value to self, organization and customer.", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Building best people - Learns, share knowledge with others and implements learning in the course of work.", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Value-oriented leadership - Objectively guiding and inspiring self and others for better outcome while managing different concerns.", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Customer focus - Directly and indirectly brings value to customer.", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Entrepreneurship - Proposes additional task for company profit purposes. Carries out tasks while considering risk and quality for organizational profit.", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Action - Carries out tasks wwith confidence to achieve results, humility to take lessons from mistakes and make required corrections.", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Specialization - Expresses deep knowledge and meets expected performance in a subject matter.", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Dynamism - Progressively delivers standard results with energy.", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Candor - Expresses self with respect for others/authority, while remaining open and honest.", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Keep it simple - Encourages clarity and simplicity in communication and work delivery.", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Innovation and Creativity - Designs/Changes process/work to improve/increase value to self, organization and customer.", TimeLimit = "Ongoing"},
                            },
                            Approved = true,
                            IsActive = true
                            
                        },
                        new CoreValuesKRA()
                        {
                            Name = "Genesys Core Values",
                            Description = "10% of total appraisal score",
                            Weight = 10,
                            keyOutcomes =
                            {
                                new KeyOutcome(){Question = "Passion - Approaches work with positivity, optimism, enthusiasm and belief", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Excellence - Delivers top quality work with little supervision in record time while constantly exploring opportunities for growth and improvement", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Collaboration - Works well with team mates, finds and shares knowledge to propel the team to success", TimeLimit = "Ongoing"},
                                new KeyOutcome(){Question = "Candor - Expresses self with respect for others/authority, while remaining open and honest.", TimeLimit = "Ongoing"},
                            },
                            Approved = true,
                            IsActive = true
                        }

                    };

                    coreValueCollection.InsertMany(data);
                }

               // SeedAppraisalConfig(dbContext);

            }
        }

        private static void SeedAppraisalConfig(IDbContext dbContext)
        {
            var collection = dbContext.Database.GetCollection<AppraisalConfig>($"{nameof(AppraisalConfig)}s");
            if (collection.AsQueryable().Any())
            {
                var data = new AppraisalConfig()
                {
                    Name = $"{DateTime.Now.Year} Appraisal Cycle",
                    Year = DateTime.Now.Year,
                    TotalCycle = 4,
                    Cycles = new List<AppraisalCycle>()
                    {
                        new AppraisalCycle(){StartDate = DateTime.Now, StopDate = DateTime.Now},
                        new AppraisalCycle(){StartDate = DateTime.Now, StopDate = DateTime.Now},
                        new AppraisalCycle(){StartDate = DateTime.Now, StopDate = DateTime.Now},
                        new AppraisalCycle(){StartDate = DateTime.Now, StopDate = DateTime.Now}
                    }
                };

                collection.InsertOne(data);
            }

        }
    }
}
