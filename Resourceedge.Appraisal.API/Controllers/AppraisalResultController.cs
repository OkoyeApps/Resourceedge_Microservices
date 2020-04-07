using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
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

            if (employee == null || appraisalConfig == null || appraisalCycle == null)
            {

                return BadRequest();
            }

            ObjectId configId = new ObjectId(appraisalConfig);
            ObjectId cycleId = new ObjectId(appraisalCycle);

            var result = appraisalResult.Get(configId, cycleId, employee);

            return Ok(result);
        }

        [HttpPost("{whoami}")]
        public IActionResult SumbitApprisal(string whoami, IEnumerable<AppraisalResultForCreationDtoString> appraisalResultForCreation)
        {
            if (appraisalResultForCreation == null)
            {
                return BadRequest();
            }

            var appraisalResultToSubmit = mapper.Map<IEnumerable<AppraisalResultForCreationDtoString>, IEnumerable<AppraisalResultForCreationDto>>(appraisalResultForCreation);

            appraisalResult.SubmitAppraisal(appraisalResultToSubmit);
            var appraisalResultToReturn = mapper.Map<IEnumerable<AppraisalResult>>(appraisalResultToSubmit);
         

            return CreatedAtRoute("MyAppraisal", new { employee = appraisalResultToSubmit.FirstOrDefault().myId, appraisalConfig = appraisalResultToSubmit.FirstOrDefault().AppraisalConfigId, appraisalCycle = appraisalResultToSubmit.FirstOrDefault().AppraisalCycleId }, appraisalResultToReturn);
        }

        [HttpPost]
        public IActionResult SumbitApprisal(IEnumerable<AppraisalResultForCreationDtoString> appraisalResultForCreation)
        {
            if (!appraisalResultForCreation.Any())
            {
                return BadRequest();
            }

            var appraisalResultToSubmit = mapper.Map<IEnumerable<AppraisalResultForCreationDtoString>, IEnumerable<AppraisalResultForCreationDto>>(appraisalResultForCreation);

            appraisalResult.SubmitAppraisal(appraisalResultToSubmit);
            var appraisalResultToReturn = mapper.Map<IEnumerable<AppraisalResult>>(appraisalResultToSubmit);

            return CreatedAtRoute("MyAppraisal", new { employee = appraisalResultToSubmit.FirstOrDefault().myId, appraisalConfig = appraisalResultToSubmit.FirstOrDefault().AppraisalConfigId, appraisalCycle = appraisalResultToSubmit.FirstOrDefault().AppraisalCycleId }, appraisalResultToReturn);
        }

        [HttpPatch("{Id}/AcceptAppraisal")]
        public async Task<IActionResult> AcceptAppraisal(string Id, JsonPatchDocument<AcceptanceStatus> entity)
        {
            ObjectId kra = new ObjectId(Id);

            AcceptanceStatus entityToUpdate = new AcceptanceStatus();
            entity.ApplyTo(entityToUpdate);

            var res = await appraisalResult.EmployeeAcceptOrReject(kra, entityToUpdate);
            if (res != null)
            {
                return Ok();
            }

            return NotFound();
        }
        [HttpPatch("{Id}/HodApproval")]
        public async Task<IActionResult> ApproveAppraisalHOD(string Id, JsonPatchDocument<AcceptanceStatus> entity)
        {
            ObjectId kra = new ObjectId(Id);

            AcceptanceStatus entityToUpdate = new AcceptanceStatus();
            entity.ApplyTo(entityToUpdate);

            var res = await appraisalResult.HodApprovalOrReject(kra, entityToUpdate);
            if (res.MatchedCount > 0)
                return Ok();

            return NotFound();


        }
    }
}
