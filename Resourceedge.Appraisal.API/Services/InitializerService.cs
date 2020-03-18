using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Services
{
    public class InitializerService
    {
        public static void Seed(IApplicationBuilder service)
        {
            var dbContext = service.ApplicationServices.GetRequiredService(typeof(IDbContext)) as IDbContext;
            if (dbContext != null)
            {
                var collection = dbContext.Database.GetCollection<KeyResultArea>("KeyResultArea");
                if (!collection.AsQueryable().Any())
                {

                    var dataToAdd = new List<KeyResultArea>()
                {
                        new KeyResultArea
                        {
                            UserId = Guid.NewGuid().ToString(),
                            AppraiserDetails = new NameEmail { Name = "Emmanuel", Id = "11111", Email = "appraisal@test.com" },
                            HodDetails = new NameEmail { Name = "EmmanuelHod", Id = "11111", Email = "Hod@test.com" },
                            keyOutcomes =
                            {
                                new KeyOutcome{ Question = "Test question 1", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString(), Status = new KeyOutcomeApprovalStatus  { Employee =true, Hod = true, IsAccepted = true } },
                                new KeyOutcome{ Question = "Test question 2", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString(), Status = new KeyOutcomeApprovalStatus { Employee =true, Hod = false, IsAccepted = true }},
                                new KeyOutcome{ Question = "Test question 3", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString(), Status =  new KeyOutcomeApprovalStatus{ Employee =false, Hod = true, IsAccepted = true }},
                            },
                            Weight = 50,
                            Approved = true,
                            Name = "School Manager"
                        },
                        new KeyResultArea
                        {
                            UserId = Guid.NewGuid().ToString(),
                            AppraiserDetails = new NameEmail { Name = "Test", Id = "11111", Email = "test@test.com" },
                            HodDetails = new NameEmail { Name = "TestlHod", Id = "11111", Email = "test@test.com" },
                            keyOutcomes =
                            {
                                new KeyOutcome{ Question = "Test question 4", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString(), Status = new KeyOutcomeApprovalStatus  { Employee =true, Hod = true, IsAccepted = true } },
                                new KeyOutcome{ Question = "Test question 5", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString(), Status = new KeyOutcomeApprovalStatus { Employee =true, Hod = false, IsAccepted = true }},
                                new KeyOutcome{ Question = "Test question 6", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString(), Status =  new KeyOutcomeApprovalStatus{ Employee =false, Hod = true, IsAccepted = true }},
                            },
                            Weight = 50,
                            Approved = true,
                            Name = "School Manager"
                        }
            };

                    collection.InsertMany(dataToAdd);

                }
            }
        }
    }
}
