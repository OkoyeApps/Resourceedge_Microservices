using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.API.Services;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    [Route("api/resultarea/{UserId}")]
    public class ResultAreaController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IKeyResultArea resultArea;
        
        public ResultAreaController(IKeyResultArea _resultArea, IMapper _mapper)
        {
            this.resultArea = _resultArea;
            mapper = _mapper;
        }


        [HttpGet("{id}", Name = "Mykpi")]
        public ActionResult<IEnumerable<KeyResultAreaDtoForCreation>> GetPersonalKpis(string id)
        {
            //var collection = ctx.Database.GetCollection<KeyResultArea>("KeyResultArea").AsQueryable();
            //var resultFromMap = collection.Where(x => x.UserId == id).ToList();
            //var mapInstance = mapper.Map<IEnumerable<KeyResultAreaDtoForCreation>>(resultFromMap);
            // return Ok(mapInstance);

            return Ok();
        }

        [HttpGet(Name = "CreateKeyOutcomes")]
        public IActionResult Index(IEnumerable<KeyResultAreaDtoForCreation> model)
        {
            //var resultFromMap = mapper.Map<IEnumerable<KeyResultAreaDtoForCreation>, IEnumerable<KeyResultAreaDtoForCreation>>(model);
            // resultArea.InsertMany(resultFromMap);

            //return CreatedAtRoute("Mykpi", new { id = model.ToArray()[0].myId }, resultFromMap);
            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> Index(int? pageSize, int pageNumber)
        {
            var data = await resultArea.Get(pageSize, pageNumber);
            return Ok(data);
        }

        [HttpPost("Update/{KeyResultAreaId}")]
        public async Task<IActionResult> UpdateKPI(string UserId, string KeyResultAreaId, KeyResultAreaForUpdateDto kpi)
        {
            ObjectId Id = new ObjectId(KeyResultAreaId);
            var keyResult = resultArea.QuerySingleByUserId(Id, UserId);

            if(keyResult != null)
            {
                var resultAreaForUpdate = mapper.Map<KeyResultArea>(kpi);

                var result = await resultArea.Update(Id, resultAreaForUpdate);

                return CreatedAtRoute("Mykpi", new {UserId, }, result);
            }

            return Ok();
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteKeyResultArea (ObjectId Id)
        {
            var keyResult = await resultArea.QuerySingle(Id);

            if (keyResult != null)
            {
                resultArea.Delete(keyResult);

                return NoContent();
            }

            return NotFound();
        }

    }
}
