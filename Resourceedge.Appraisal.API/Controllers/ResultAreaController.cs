using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
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
            collection.InsertOne(new KeyResultAreas());
            //collection.InsertOne(new BsonDocument
            //{
            //    { "name", "MongoDB" },
            //    { "type", "Database" },
            //    { "count", 1 },
            //    { "info", new BsonDocument
            //        {
            //            { "x", 203 },
            //            { "y", 102 }
            //        }}
            //});

            return Ok(true);
        }

    }
}
