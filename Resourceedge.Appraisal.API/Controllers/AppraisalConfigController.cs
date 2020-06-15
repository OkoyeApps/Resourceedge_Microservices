using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.API.ResourceParamters;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;

namespace Resourceedge.Appraisal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/appraisalconfig")]
    public class AppraisalConfigController : ControllerBase
    {
        private readonly IAppraisalConfig appraisalConfig;
        private readonly IMapper mapper;

        public AppraisalConfigController(IAppraisalConfig _appraisalConfig, IMapper mapper)
        {
            appraisalConfig = _appraisalConfig;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetAppraisalConfigurations")]
        public async Task<IActionResult> GetAppraisalConfigs([FromRoute]AppraisalConfigParameters parameter)
        {
            var resultFromRepo = await appraisalConfig.Get(parameter);
            return Ok(mapper.Map<IEnumerable<AppraisalCongifurationForViewDto>>(resultFromRepo));
        }

        [HttpPost(Name = "AddAppraisalConfig")]
        public IActionResult AddAppraisalConfig(AppraisalConfigForCreationDto param)
        {
            var entity = mapper.Map<AppraisalConfig>(param);
            var result = appraisalConfig.Insert(entity);

            return result ? CreatedAtRoute("GetAppraisalConfigurations", new { }, mapper.Map<AppraisalConfigForCreationDto>(entity)) : ValidationProblem(ModelState);
        }

        [HttpPatch("{Id}")]
        public IActionResult UpdateAppraisalConfig(string Id, JsonPatchDocument<AppraisalCycleClass> param)
        {
            var appraisalClass = new AppraisalCycleClass();
            param.ApplyTo(appraisalClass);
            if (TryValidateModel(appraisalClass))
            {
                var entity = mapper.Map<AppraisalCycle>(appraisalClass);
                var result = appraisalConfig.Update(new ObjectId(Id), entity);
                return NoContent();

            }
            return ValidationProblem(ModelState);
        }

       [HttpGet("GetActive")]
       public IActionResult GetCurrentAppraisal()
       {
            var result = appraisalConfig.GetActiveCycle();

            return Ok(result);
       }

        [HttpPost("Activate/{cycleId}")]
        public IActionResult ActivateAppraisal(string cycleId)
        {
            var result = appraisalConfig.ActivateCycle(cycleId);
            if (result)
            {
                return Ok(new { success = true });
            }
            return Ok(new { success = false });
        }
    }
}