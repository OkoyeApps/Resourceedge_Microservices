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
        public async Task<IActionResult> Index(int? pageSize, int pageNumber)
        {
            var data = await resultArea.Get(pageSize, pageNumber);
            return Ok(data);
        }


        [HttpGet(Name = "Mykpi")]
        public ActionResult<IEnumerable<KeyResultAreaDtoForCreation>> GetPersonalKpis(string UserId)
        {
            var resultFromMap = resultArea.GetPersonalkpis(UserId);
            var mapInstance = mapper.Map<IEnumerable<KeyResultAreaDtoForCreation>>(resultFromMap);
            return Ok(mapInstance);
        }

        [HttpPost(Name = "CreateKeyOutcomes")]
        public IActionResult Index(string UserId, IEnumerable<KeyResultAreaDtoForCreation> model)
        {
            var entityToAdd = mapper.Map<IEnumerable<KeyResultAreaDtoForCreation>, IEnumerable<KeyResultArea>>(model);            
            resultArea.AddKeyOutcomes(entityToAdd);

            var entityToReturn = mapper.Map<IEnumerable<KeyResultArea>>(entityToAdd);
            return CreatedAtRoute("Mykpi", new {UserId = UserId}, entityToReturn);
        }

        [HttpPatch("Update/{KeyResultAreaId}")]
        public async Task<IActionResult> UpdateKPI(string UserId, string KeyResultAreaId, KeyResultAreaForUpdateDto kpi)
        {
            ObjectId Id = new ObjectId(KeyResultAreaId);
            var keyResult = resultArea.QuerySingle(Id);

            if (keyResult != null)
            {
                var resultAreaForUpdate = mapper.Map<KeyResultArea>(kpi);

                var entityToUpdate = await resultArea.Update(Id, resultAreaForUpdate);
                var entityToReturn = mapper.Map<KeyResultAreaDtoForCreation>(entityToUpdate);

                return CreatedAtRoute("Mykpi", new { UserId = UserId}, entityToReturn);
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
