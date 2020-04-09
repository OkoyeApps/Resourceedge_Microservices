﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Resourceedge.Appraisal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/resultarea/{empId:int}")]
    public class ResultAreaController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IKeyResultArea resultArea;

        public ResultAreaController(IKeyResultArea _resultArea, IMapper _mapper)
        {
            this.resultArea = _resultArea;
            mapper = _mapper;
        }
        public async Task<IActionResult> Index(int? pageSize, int pageNumber)
        {
            var data = await resultArea.Get(pageSize, pageNumber);
            return Ok(data);
        }

        [HttpGet(Name = "Mykpi")]

        public ActionResult<IEnumerable<KeyResultAreaDtoForCreation>> GetPersonalKpis(int empId)
        {
            var resultFromMap = resultArea.GetPersonalkpis(empId);
            var mapInstance = mapper.Map<IEnumerable<KeyResultAreaForViewDto>>(resultFromMap);
            return Ok(mapInstance);
        }

        [HttpGet("{KeyResultAreaId}", Name = "GetEmployeeKpiById")]
        public ActionResult GetEmployeeKpiById(int empId, string KeyResultArea)
        {
            var data = resultArea.GetPersonalkpis(empId, KeyResultArea).FirstOrDefault();
            return Ok(data);
        }

        [HttpPost(Name = "CreateKeyOutcomes")]
        public async Task<IActionResult> CreateKeyResultArea(string empId, IEnumerable<KeyResultAreaDtoForCreation> model)
        {
            try
            {
                foreach (var item in model)
                {
                    item.myId = empId;
                }

                var entityToAdd = mapper.Map<IEnumerable<KeyResultAreaDtoForCreation>, IEnumerable<KeyResultArea>>(model);
                var result = await resultArea.AddKeyOutcomes(entityToAdd);

                var entityToReturn = mapper.Map<IEnumerable<KeyResultArea>>(entityToAdd);
                resultArea.SendApprovalNotification(entityToReturn);
                return CreatedAtRoute("Mykpi", new { empId = empId }, entityToReturn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPatch("Update/{KeyResultAreaId}")]
        public async Task<IActionResult> UpdateKPI(int empId, string KeyResultAreaId, JsonPatchDocument<KeyResultAreaForUpdateDto> entityForUpdate)
        {
            var Kpi = new KeyResultAreaForUpdateDto();
            entityForUpdate.ApplyTo(Kpi);

            ObjectId Id = new ObjectId(KeyResultAreaId);
            var keyResult = await resultArea.QuerySingleByUserId(Id, empId);

            if (keyResult != null)
            {
                var resultAreaForUpdate = mapper.Map<KeyResultAreaForUpdateMainDto>(Kpi);

                var entityToUpdate = resultArea.Update(Id, resultAreaForUpdate);
                var entityToReturn = mapper.Map<KeyResultAreaDtoForCreation>(entityToUpdate);

                return CreatedAtRoute("Mykpi", new { empId = empId }, entityToReturn);
            }

            return Ok();
        }

        [HttpPost("Update/{KeyResultAreaId}")]
        public async Task<IActionResult> UpdateKPIs(int empId, string KeyResultAreaId, KeyResultAreaForUpdateDto entityForUpdate)
        {
            ObjectId Id = new ObjectId(KeyResultAreaId);
            var keyResult = await resultArea.QuerySingleByUserId(Id, empId);

            if (keyResult != null)
            {
                var resultAreaForUpdate = mapper.Map<KeyResultAreaForUpdateMainDto>(entityForUpdate);

                var entityToUpdate = resultArea.Update(Id, resultAreaForUpdate);
                var entityToReturn = mapper.Map<KeyResultAreaDtoForCreation>(entityToUpdate);

                return CreatedAtRoute("Mykpi", new { empId = empId }, entityToReturn);
            }

            return NotFound();
        }

        [HttpPatch("{KeyResultAreaId}/KeyOutcome/{KeyOutcomeId}")]
        public async Task<IActionResult> UpdateKeyOutcome(int empId, string KeyResultAreaId, string KeyOutcomeId, JsonPatchDocument<KeyOutcomeForUpdateDto> entityForUpdate)
        {
            var keyOutcomeForUpdate = new KeyOutcomeForUpdateDto();
            entityForUpdate.ApplyTo(keyOutcomeForUpdate);

            ObjectId Id = new ObjectId(KeyResultAreaId);
            ObjectId keyOutcomeId = new ObjectId(KeyOutcomeId);

            var result = await resultArea.UpdateKeyOutcome(Id, keyOutcomeId, empId, keyOutcomeForUpdate);
            if (result > 0)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost("member/{memberId}/{KeyResultAreaId}/Approval/{whoami}")]
        public async Task<IActionResult> ApprovalKeyOutCome(int empId, int memberId,  string KeyResultAreaId, string whoami, StatusForUpdateDto entity)
        {
            var keyResultAreaId = new ObjectId(KeyResultAreaId);

            if (entity == null)
            {
                return BadRequest();
            }

            var result = await resultArea.HodApproval(empId, memberId,  keyResultAreaId, whoami, entity);
            if (result != null)
            {
                return CreatedAtRoute("GetEmployeeKpiById", new { empId = empId, KeyResultAreaId = result.Id.ToString() }, result);
            }

            return NotFound();
        }

        [HttpPost("Approval")]
        public async Task<IActionResult> ApprovalKeyOutCome(int empId, StatusForUpdateDto entity)
        {
            //var keyResultAreaId = new ObjectId(KeyResultAreaId);

            if (entity == null)
            {
                return BadRequest();
            }

            var result = await resultArea.EmployeeApproval(empId, entity);
            if (result > 0)
            {
                return Ok();
            }

            return NoContent();
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteKeyResultArea(string empId, string Id)
        {
            ObjectId objId = new ObjectId(Id);
            ObjectId objempId = new ObjectId(empId);
            var keyResult = await resultArea.QuerySingle(objId);

            if (keyResult != null)
            {
                resultArea.Delete(objId);

                return NoContent();
            }

            return NotFound();
        }

        [HttpGet("checkuploaded")]
        public IActionResult CheckUserUploadedEpaForYear(int empId)
        {
            var result = resultArea.HasUploadedEpa(empId);
            return Ok(result);
        } 
    }
}
