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

        [HttpPost("{whoami}")]
        public IActionResult SumbitApprisal(string whoami, AppraisalResultForCreationDtoString appraisalResultForCreation)
        {
            if (appraisalResultForCreation == null)
            {
                return BadRequest();
            }

            List<AppraisalKeyOutcomeDto> Outcomes = new List<AppraisalKeyOutcomeDto>();

            foreach (var item in appraisalResultForCreation.KeyOutcomeScore)
            {
                var outcome = new AppraisalKeyOutcomeDto()
                {
                    EmployeeScore = item.EmployeeScore,                  
                    KeyOutcomeId = new ObjectId(item.KeyOutcomeId)
                };
                Outcomes.Add(outcome);
            }

            var appraisalResultToSubmit = new AppraisalResultForCreationDto()
            {
                myId = appraisalResultForCreation.myId,
                whoami = whoami,
                AppraisalConfigId = new ObjectId(appraisalResultForCreation.AppraisalConfigId),
                AppraisalCycleId = new ObjectId(appraisalResultForCreation.AppraisalCycleId),
                KeyResultAreaId = new ObjectId(appraisalResultForCreation.KeyResultAreaId),
                KeyOutcomeScore = Outcomes
            };

            appraisalResult.SubmitAppraisal(appraisalResultToSubmit);
            //var appraisalResultToReturn = mapper.Map<AppraisalResult>(appraisalResultForCreation);

            return CreatedAtRoute("MyAppraisal", new { employee = appraisalResultToSubmit.myId, appraisalConfig = appraisalResultToSubmit.AppraisalConfigId, appraisalCycle = appraisalResultToSubmit.AppraisalCycleId }, appraisalResultToSubmit);
        }

        [HttpPost]
        public IActionResult SumbitApprisal(AppraisalResultForCreationDtoString appraisalResultForCreation)
        {
            if (appraisalResultForCreation == null)
            {
                return BadRequest();
            }

            List<AppraisalKeyOutcomeDto> Outcomes = new List<AppraisalKeyOutcomeDto>();

            foreach (var item in appraisalResultForCreation.KeyOutcomeScore)
            {
                var outcome = new AppraisalKeyOutcomeDto()
                {
                    EmployeeScore = item.EmployeeScore,
                    KeyOutcomeId = new ObjectId(item.KeyOutcomeId)
                };
                Outcomes.Add(outcome);
            }

            var appraisalResultToSubmit = new AppraisalResultForCreationDto()
            {
                myId = appraisalResultForCreation.myId,
                AppraisalConfigId = new ObjectId(appraisalResultForCreation.AppraisalConfigId),
                AppraisalCycleId = new ObjectId(appraisalResultForCreation.AppraisalCycleId),
                KeyResultAreaId = new ObjectId(appraisalResultForCreation.KeyResultAreaId),
                KeyOutcomeScore = Outcomes
            };

            appraisalResult.SubmitAppraisal(appraisalResultToSubmit);
            //var appraisalResultToReturn = mapper.Map<AppraisalResult>(appraisalResultForCreation);

            return CreatedAtRoute("MyAppraisal", new { employee = appraisalResultToSubmit.myId, appraisalConfig = appraisalResultToSubmit.AppraisalConfigId, appraisalCycle = appraisalResultToSubmit.AppraisalCycleId }, appraisalResultToSubmit);
        }
    }
}
