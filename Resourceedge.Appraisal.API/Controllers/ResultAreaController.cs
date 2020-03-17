using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using System;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    [Route("api/resultarea")]
    public class ResultAreaController : ControllerBase
    {
        private readonly IDbContext ctx;

        public ResultAreaController(IDbContext _ctx)
        {
            ctx = _ctx;
        }

        public IActionResult Index()
        {
            var collection = ctx.Database.GetCollection<KeyResultAreas>("KeyResultArea");
            var aa = new KeyResultAreas()
            {
                AppraiserDetails = new NameEmail { Name = "Emmanuel", Id = "11111", Email = "appraisal@test.com" },
                HodDetails = new NameEmail { Name = "EmmanuelHod", Id = "11111", Email = "Hod@test.com" },
                keyOutcomes =
                {
                    new KeyOutcome{ Question = "Test question 1", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString(), Status = new KeyOutcomeApprovalStatus  { Employee =true, Hod = true, IsAccepted = true } },
                    new KeyOutcome{ Question = "Test question 2", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString(), Status = new KeyOutcomeApprovalStatus { Employee =true, Hod = false, IsAccepted = true }},
                    new KeyOutcome{ Question = "Test question 3", TimeLimit = BsonDateTime.Create(DateTime.Now).ToString(), Status =  new KeyOutcomeApprovalStatus{ Employee =false, Hod = true, IsAccepted = true }},
                }, 
                Weight = 50, Approved = true, Name = "School Manager"
            };
            collection.InsertOne(aa); 


            return Ok(true);
        }

    }
}
