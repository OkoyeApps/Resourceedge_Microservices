﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Appraisal.Domain.Queries;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resourceedge.Appraisal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/finalResult")]
    public class FinalResultController : ControllerBase
    {
        private readonly IAppraisalFinalResult finalResultRepo;
        private readonly IMapper mapper;
        private readonly IAppraisalResult appraisalResult;

        public FinalResultController(IAppraisalFinalResult _finalResult, IMapper _mapper, IAppraisalResult _appraisalResult)
        {
            finalResultRepo = _finalResult;
            mapper = _mapper;
            appraisalResult = _appraisalResult;
        }
        [HttpGet("{cycleId}/{empId}")]
        public IActionResult GetEmployeeResult(string cycleId, int empId)
        {
            ObjectId CycleId = new ObjectId(cycleId);

            var result = finalResultRepo.GetEmployeeResult(empId, CycleId);
            var resultToReturn = mapper.Map<FinalResultDtoForView>(result);

            if (resultToReturn != null)
            {
                return Ok(resultToReturn);
            }

            return NoContent();
        }

        [HttpGet("{cycleId}")]
        public async Task<IActionResult> AllAppraisalResult([FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }

            var result = await finalResultRepo.GetAllResultByCycle(ObjectId.Parse(configParam.Cycle));
            if(result != null)
            {
                return Ok(result);
            }
            
            return NoContent();
        }

        [HttpGet("~/api/Report")]
        public async Task<IActionResult> AllAppraisalResultByLocation([FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }

            var result = await finalResultRepo.GetAllResultByCycle(ObjectId.Parse(configParam.Cycle));
            if (result != null)
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpGet("~/api/Report/{group}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> AppraisalResultByGroup(string group, int pageNumber, int pageSize, [FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }

            var result = await finalResultRepo.GetAppraisalResultByGroup(group, pageNumber, pageSize, ObjectId.Parse(configParam.Cycle));
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("~/api/Report/Organisation/Count")]
        public async Task<IActionResult> GetOrganisation([FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }

            var result = await finalResultRepo.GetOrgaization(ObjectId.Parse(configParam.Cycle));
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }
        [HttpGet("recalculate")]
        public async Task<IActionResult> ReCalculateAppraisal([FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }

            var result = await finalResultRepo.ReCalculateFinalAppraisalResult(ObjectId.Parse(configParam.Cycle));
            if (result)
            {
                return Ok(result);
            }
            return NoContent();
        }

    }
}
