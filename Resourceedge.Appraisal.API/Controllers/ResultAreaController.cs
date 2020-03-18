using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.API.Services;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    [Route("api/resultarea/{UserId}")]
    public class ResultAreaController : ControllerBase
    {
        private readonly IKeyResultArea resultArea;
        private readonly IMapper mapper;

        public ResultAreaController(IKeyResultArea _resultArea, IMapper _mapper)
        {
            this.resultArea = _resultArea;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? pageSize, int pageNumber)
        {

            var data = await resultArea.Get(pageSize, pageNumber);           
            return Ok(data);
        }
     
        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateKPI(ObjectId Id, KeyResultAreaForUpdateDto kpi)
        {
            var keyResult = resultArea.QuerySingle(Id);

            if(keyResult != null)
            {
                var resultAreaForUpdate = mapper.Map<KeyResultArea>(kpi);

                var result = await resultArea.Update(Id, resultAreaForUpdate);

                return CreatedAtRoute("Mykpi", new { }, result);
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
