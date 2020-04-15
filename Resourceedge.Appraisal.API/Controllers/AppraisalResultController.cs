using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IAppraisalFinalResult finalResultRepo;

        public AppraisalResultController(IAppraisalResult _appraisalResult, IMapper _mapper, IAppraisalFinalResult _finalResultRepo)
        {
            appraisalResult = _appraisalResult;
            mapper = _mapper;
            finalResultRepo = _finalResultRepo;
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

            finalResultRepo.CalculateResult(appraisalResultToReturn.FirstOrDefault().myId, appraisalResultToReturn.FirstOrDefault().AppraisalCycleId);

            return Ok(new { success = true });

            //return CreatedAtRoute("MyAppraisal", new { employee = appraisalResultToSubmit.FirstOrDefault().myId, appraisalConfig = appraisalResultToSubmit.FirstOrDefault().AppraisalConfigId, appraisalCycle = appraisalResultToSubmit.FirstOrDefault().AppraisalCycleId }, appraisalResultToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> SumbitApprisal(IEnumerable<AppraisalResultForCreationDtoString> appraisalResultForCreation)
        {
            if (!appraisalResultForCreation.Any())
            {
                return BadRequest();
            }

            var appraisalResultToSubmit = mapper.Map<IEnumerable<AppraisalResultForCreationDtoString>, IEnumerable<AppraisalResultForCreationDto>>(appraisalResultForCreation);

            await appraisalResult.SubmitAppraisal(appraisalResultToSubmit);
            var appraisalResultToReturn = mapper.Map<IEnumerable<AppraisalResult>>(appraisalResultToSubmit);
            if(appraisalResultToReturn.Any())
            {
                finalResultRepo.CalculateResult(appraisalResultToReturn.FirstOrDefault().myId, appraisalResultToReturn.FirstOrDefault().AppraisalCycleId);
            }

            return Ok(new { success = true});
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

        [Route("hasparticipated/{employeeId}"),HttpGet]
        public async Task<IActionResult> HasParticipated(int employeeId)
        {
            var result = await appraisalResult.HasPaticipatedInAppraisal(employeeId);
            return  Ok(result);
        }


        [Route("getemployeetoappraise/{employeeid}/{whoami}")]
        public async Task<IActionResult> GetEmployeesWithSubmittedAppraisal(int employeeid, string whoami)
        {
            try
            {
                var result = await appraisalResult.GetEmployeesToAppraise(employeeid, whoami);
                var Dto = mapper.Map<IEnumerable<AppraisalForApprovalViewDto>>(result);
                return Ok(Dto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
