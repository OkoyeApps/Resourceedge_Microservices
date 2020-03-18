using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    [Route("api/resultarea")]
    public class ResultAreaController : ControllerBase
    {
        private readonly IDbContext ctx;
        private readonly IMapper mapper;

        public ResultAreaController(IDbContext _ctx, IMapper _mapper)
        {
            ctx = _ctx;
            mapper = _mapper;
        }


        [HttpGet("{id}", Name = "Mykpi")]
        public ActionResult<IEnumerable<KeyResultAreaDtoForCreation>> GetPersonalKpis(string id)
        {
            var collection = ctx.Database.GetCollection<KeyResultAreas>("KeyResultArea").AsQueryable();
            var resultFromMap = collection.Where(x => x.UserId == id).ToList();
            var mapInstance = mapper.Map<IEnumerable<KeyResultAreaDtoForCreation>>(resultFromMap);
            return Ok(mapInstance);
        }

        [HttpGet(Name = "CreateKeyOutcomes")]
        public IActionResult Index(IEnumerable<KeyResultAreaDtoForCreation> model)
        {
            var collection = ctx.Database.GetCollection<KeyResultAreas>("KeyResultArea");
            var resultFromMap = mapper.Map<IEnumerable<KeyResultAreaDtoForCreation>, IEnumerable<KeyResultAreas>>(model);
            collection.InsertMany(resultFromMap);

            return CreatedAtRoute("Mykpi", new { id = model.ToArray()[0].myId }, resultFromMap);
        }

    }
}
