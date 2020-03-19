using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    [Route("api/Appraisal")]
    public class AppraisalResultController : ControllerBase
    {
        private readonly IAppraisalResult appraisalResult;
        private readonly IMapper mapper;

        public AppraisalResultController(IAppraisalResult _appraisalResult, IMapper _mapper)
        {
            appraisalResult = _appraisalResult;
            mapper = _mapper;
        }
        
        [HttpGet(Name = "MyAppraisal")]
        public IActionResult EmployeeAppraisal(int? employee, string appraisalConfig, string appraisalCycle)
        {

            if (employee == null || appraisalConfig == null || appraisalCycle == null){

                return BadRequest();
            }
                    
            ObjectId configId = new ObjectId(appraisalConfig);
            ObjectId cycleId = new ObjectId(appraisalCycle);

           var result = appraisalResult.Get(configId, cycleId, employee);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult SumbitApprisal(AppraisalResultForCreationDto appraisalResultForCreation)
        {
            if (appraisalResultForCreation == null)
            {
                return BadRequest();
            }

            var appraisalResultToAdd = mapper.Map<AppraisalResult>(appraisalResultForCreation);

            appraisalResult.InsertResult(appraisalResultToAdd);
            var appraisalResultToReturn = mapper.Map<AppraisalResult>(appraisalResultForCreation);

            return CreatedAtRoute("MyAppraisal", new { employee = appraisalResultToReturn.myId, appraisalConfig = appraisalResultToReturn.AppraisalConfigId, appraisalCycle = appraisalResultToReturn.AppraisalCycleId }, appraisalResultToReturn);
        }

        public IActionResult
    }
}
