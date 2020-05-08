using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Appraisal.Domain.Queries;
using Resourceedge.Common.Archive;
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
        private readonly IKeyResultArea resultAreaRepo;

        public AppraisalResultController(IAppraisalResult _appraisalResult, IMapper _mapper, IAppraisalFinalResult _finalResultRepo, ITeamRepository _teamRepo, IKeyResultArea _resultAreaRepo)
        {
            appraisalResult = _appraisalResult;
            mapper = _mapper;
            finalResultRepo = _finalResultRepo;
            teamRepo = _teamRepo;
            resultAreaRepo = _resultAreaRepo;
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
            if (result.Item1)
            {
                var appraisalResultToReturn = mapper.Map<IEnumerable<AppraisalResult>>(appraisalResultToSubmit);

                if (appraisalResultToReturn.Any())
                {
                    finalResultRepo.CalculateResult(employeeId, ObjectId.Parse(configParam.Cycle));
                }

                return Ok(new { success = true });
            }

            return BadRequest(new { message = result.Item2 });
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
        [HttpPost("HodApproval/{hodId}/{empId}")]
        public async Task<IActionResult> ApproveAppraisalHOD(int hodId, int empId, [FromBody]IEnumerable<HodApprovalDto> approvalStatus, [FromQuery]AppraisalQueryParam configParam)
        {
            var configExist = await appraisalResult.CheckAppraisalConfigurationDetails(configParam);
            if (!configExist)
            {
                return BadRequest(new { message = "Invalid Configuration details" });
            }

            var employee = await resultAreaRepo.GetEmployee(empId);
            if (employee == null)
            {
                return BadRequest(new { message = "Employee does not exist" });
            }

            var hod = await resultAreaRepo.GetEmployee(hodId);
            if(hod == null)
            {
                return BadRequest(new { message = "Hod details not found" });
            }
                       

            var res = await appraisalResult.HodApprovalOrReject(hod, employee, approvalStatus, ObjectId.Parse(configParam.Cycle));
            if (res)
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

        [HttpGet, Route("{employeeId}/kraforappraisal")]
        public async Task<IActionResult> GetKraforAppraisal(int employeeId, [FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if(configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }

            var currentCycle = configDetails.Cycles.FirstOrDefault(x => x.Id ==ObjectId.Parse(configParam.Cycle));
            if(currentCycle == null)
            {
                return NotFound(new { message = "Appraisal cycle not found" });
            }

            var resultFromMap = appraisalResult.GetAcceptedKRAForAppraisal(employeeId, currentCycle);
            var mapInstance = mapper.Map<IEnumerable<KeyResultAreaForViewDto>>(resultFromMap).ToList();

            mapInstance.RemoveAll(x => !x.keyOutcomes.Any());
            return Ok(mapInstance);
        }

        [HttpGet("Updatekeyresultarea")]
        public async Task<IActionResult> UpdateExistingAppraisalResult([FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }
            var result = await appraisalResult.UpdateKeyResultAreaForExistingResult(configParam.Cycle);
            if (result)
            {
                return Ok(new {success = "Update completed" });
            }

            return BadRequest(new { message = "something went wrong" });
        }

        [HttpGet("ResetAppraisal/{AppraiserId}/{EmployeeId}")]
        public async Task<IActionResult> ResetAppraisal(int AppraiserId, int EmployeeId, [FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }
            var result = await appraisalResult.RestAppraisal(EmployeeId, AppraiserId, ObjectId.Parse(configParam.Cycle));
            if (result)
            {
                return Ok(new { success = "Update completed" });
            }

            return BadRequest(new { message = "something went wrong" });
        }

        [HttpDelete("ResetEmployeeAppraisal/{EmployeeId}")]
        public async Task<IActionResult> ResetEmployeeAppraisal(int EmployeeId, [FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }

            var result = await appraisalResult.ResetEmployeeAppraisal(EmployeeId, ObjectId.Parse(configParam.Cycle));
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

    }
   
}
