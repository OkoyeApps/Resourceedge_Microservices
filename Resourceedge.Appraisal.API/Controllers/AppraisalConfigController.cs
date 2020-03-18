using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.API.ResourceParamters;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;

namespace Resourceedge.Appraisal.API.Controllers
{
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
            return Ok(mapper.Map<IEnumerable<AppraisalConfig>>(resultFromRepo));
        }

        [HttpPost(Name = "AddAppraisalConfig")]
        public IActionResult AddAppraisalConfig(AppraisalConfigForCreationDto param)
        {
            var entity = mapper.Map<AppraisalConfigForCreationDto, AppraisalConfig>(param);
            var result = appraisalConfig.Insert(entity);

            return result ? Ok() : ValidationProblem(ModelState);
        }

        
    }
}