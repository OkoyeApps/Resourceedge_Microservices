using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Appraisal.Domain.Queries;
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
        private readonly ITeamRepository teamRepo;

        public AppraisalResultController(IAppraisalResult _appraisalResult, IMapper _mapper, IAppraisalFinalResult _finalResultRepo, ITeamRepository _teamRepo)
        {
            appraisalResult = _appraisalResult;
            mapper = _mapper;
            finalResultRepo = _finalResultRepo;
            teamRepo = _teamRepo;
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

        [HttpPost("Appraiser/{employeeId}")]
        public async Task<IActionResult> AppraiseEmployee(int employeeId, [FromQuery]AppraisalQueryParam configParam, [FromBody]IEnumerable<AppraisalResultForCreationDtoString> appraisalResultForCreation)
        {
            if (appraisalResultForCreation == null)
            {
                return BadRequest(new {message = "No Result Sent" });
            }

            var hasDoneAppraisal = await appraisalResult.HasPaticipatedInAppraisal(employeeId);
            if (!hasDoneAppraisal)
            {
                return BadRequest(new { message = "Employee has not participated in this appraisal!" });
            }

            var configExist = await appraisalResult.CheckAppraisalConfigurationDetails(configParam);
            if (!configExist)
            {
                return BadRequest( new { message = "Invalid Configuration details" });
            }

            var appraisalResultToSubmit = mapper.Map<IEnumerable<AppraisalResultForCreationDtoString>, IEnumerable<AppraisalResultForCreationDto>>(appraisalResultForCreation);

            var result = await appraisalResult.AppraiseEmployee(employeeId, appraisalResultToSubmit) ;
            if (result)
            {
                var appraisalResultToReturn = mapper.Map<IEnumerable<AppraisalResult>>(appraisalResultToSubmit);

                if (appraisalResultToReturn.Any())
                {
                    finalResultRepo.CalculateResult(employeeId, ObjectId.Parse(configParam.Cycle));
                }

                return Ok(new { success = true });
            }
            return BadRequest(new { message = "You have already appraised these Employee or an error occured" });

        }

        [HttpPost, Route("self/{employeeId}")]
        public async Task<IActionResult> SumbitApprisal(int employeeId, [FromQuery]AppraisalQueryParam configParam, [FromBody]IEnumerable<AppraisalResultForCreationDtoString> appraisalResultForCreation)
        {
            if (!appraisalResultForCreation.Any())
            {
                return BadRequest(new { message = "No Result Sent" });
            }

            var hasDoneAppraisal = await appraisalResult.HasPaticipatedInAppraisal(employeeId);
            if (hasDoneAppraisal)
            {
                return BadRequest(new { message = "You have already participated in this appraisal" });
            }

            var configExist = await appraisalResult.CheckAppraisalConfigurationDetails(configParam);
            if (!configExist)
            {
                return BadRequest(new { message = "Invalid Configuration details" });
            }                

            var appraisalResultToSubmit = mapper.Map<IEnumerable<AppraisalResultForCreationDtoString>, IEnumerable<AppraisalResultForCreationDto>>(appraisalResultForCreation);
                       
            var result = await appraisalResult.SubmitAppraisal(employeeId, appraisalResultToSubmit);
            if (result)
            {
                var appraisalResultToReturn = mapper.Map<IEnumerable<AppraisalResult>>(appraisalResultToSubmit);

                if (appraisalResultToReturn.Any())
                {
                    finalResultRepo.CalculateResult(employeeId, ObjectId.Parse(configParam.Cycle));
                }

                return Ok(new { success = true });
            }

            return BadRequest(new { message = "Something went wrong" });
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
        public async Task<IActionResult> GetEmployeesWithSubmittedAppraisal(int employeeid, string whoami, [FromQuery]AppraisalQueryParam model )
        {
            try
            {
                var configExist = await appraisalResult.CheckAppraisalConfigurationDetails(model);
                if (!configExist)
                {
                    return NotFound(new { error = "Appraisal configuration details not found"});
                }

                var result = await appraisalResult.GetEmployeesToAppraise(employeeid, model.Config, model.Cycle, whoami);
                var Dto = mapper.Map<IEnumerable<AppraisalForApprovalViewDto>>(result);
                //THIS COULD BE FIXED LATER WITH MONGO QUERY
                //rearrange object
                Dto.ToList().ForEach(x =>
                {
                    x.Kra_Details.ToList().ForEach(y =>
                    {
                        y.KeyResultArea.whoami = y.KeyResultArea.HeadOfDepartment.EmployeeId == employeeid ? "hod" : "appraiser";
                    });
                });
                return Ok(Dto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
   
}
