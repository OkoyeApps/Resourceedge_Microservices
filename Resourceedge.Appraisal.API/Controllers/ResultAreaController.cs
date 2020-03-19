using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        public IActionResult CreateKeyResultArea(string UserId, IEnumerable<KeyResultAreaDtoForCreation> model)
        {
            var entityToAdd = mapper.Map<IEnumerable<KeyResultAreaDtoForCreation>, IEnumerable<KeyResultArea>>(model);            
            resultArea.AddKeyOutcomes(entityToAdd);

            var entityToReturn = mapper.Map<IEnumerable<KeyResultArea>>(entityToAdd);
            return CreatedAtRoute("Mykpi", new {UserId = UserId}, entityToReturn);
        }

        [HttpPatch("Update/{KeyResultAreaId}")]
        public async Task<IActionResult> UpdateKPI(string UserId, string KeyResultAreaId, JsonPatchDocument<KeyResultAreaForUpdateDto> entityForUpdate)
        {
            var Kpi = new KeyResultAreaForUpdateDto();
            entityForUpdate.ApplyTo(Kpi);

            ObjectId Id = new ObjectId(KeyResultAreaId);
            var keyResult = await resultArea.QuerySingleByUserId(Id, UserId);

            if (keyResult != null)
            {
                var resultAreaForUpdate = mapper.Map<KeyResultAreaForUpdateMainDto>(Kpi);

                var entityToUpdate = await resultArea.Update(Id, resultAreaForUpdate);
                var entityToReturn = mapper.Map<KeyResultAreaDtoForCreation>(entityToUpdate);

                return CreatedAtRoute("Mykpi", new { UserId = UserId}, entityToReturn);
            }

            return Ok();
        }

        [HttpPost("Update/{KeyResultAreaId}")]
        public async Task<IActionResult> UpdateKPIs(string UserId, string KeyResultAreaId, KeyResultAreaForUpdateDto entityForUpdate)
        {
            //var Kpi = new KeyResultAreaForUpdateDto();
            //entityForUpdate.ApplyTo(Kpi);

            ObjectId Id = new ObjectId(KeyResultAreaId);
            var keyResult = await resultArea.QuerySingleByUserId(Id, UserId);

            if (keyResult != null)
            {
                var resultAreaForUpdate = mapper.Map<KeyResultAreaForUpdateMainDto>(entityForUpdate);

                var entityToUpdate = await resultArea.Update(Id, resultAreaForUpdate);
                var entityToReturn = mapper.Map<KeyResultAreaDtoForCreation>(entityToUpdate);

                return CreatedAtRoute("Mykpi", new { UserId = UserId }, entityToReturn);
            }

            return NotFound();
        }

        [HttpPatch("{KeyResultAreaId}/KeyOutcome/{KeyOutcomeId}")]
        public async Task<IActionResult> UpdateKeyOutcome(string UserId, string KeyResultAreaId, string KeyOutcomeId, JsonPatchDocument<KeyOutcomeForUpdateDto> entityForUpdate)
        {
            var keyOutcomeForUpdate = new KeyOutcomeForUpdateDto();
            entityForUpdate.ApplyTo(keyOutcomeForUpdate);

            ObjectId Id = new ObjectId(KeyResultAreaId);
            ObjectId keyOutcomeId = new ObjectId(KeyOutcomeId);
         
            var result = await resultArea.UpdateKeyOutcome(Id, keyOutcomeId, UserId, keyOutcomeForUpdate);
            if(result > 0)
            {
                return Ok(result);
            }            

            return NotFound();
        }

       
                     
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteKeyResultArea (ObjectId Id)
        {
            var keyResult = await resultArea.QuerySingle(Id);

            if (keyResult != null)
            {
                resultArea.Delete(Id);

                return NoContent();
            }

            return NotFound();
        }

    }
}
