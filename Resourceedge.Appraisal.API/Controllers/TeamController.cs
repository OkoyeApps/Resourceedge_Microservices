﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Common.Archive;
using Resourceedge.Common.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    [Route("api/team/{Id}")]
    public class TeamController : Controller
    {
        private readonly ITeamRepository teamRepo;
        private readonly IMapper mapper;

        public TeamController(ITeamRepository _teamRepo, IMapper _mapper)
        {
            teamRepo = _teamRepo;
            mapper = _mapper;
        }

        [HttpGet(Name = "GetEmployeesToAppraise")]
        public async Task<IActionResult> GetEmployeesToAppraise(int Id)
        {
            var resultFromRepo = await teamRepo.GetEmployeesToAppraise(Id);
            var resultForView = mapper.Map<IEnumerable<OldEmployeeDto>>(resultFromRepo);
            return Ok(resultForView);
        }

        [HttpGet("teammeber/{TeammemberId}")]
        public async Task<IActionResult> ViewTeamMemberKpi(int Id, int TeammemberId)
        {
            var resultFromRepo = await teamRepo.GetTeamMemberKpi(Id, TeammemberId);
            return Ok(resultFromRepo);

        }

        [Route("~/api/Supervisors")]
        [HttpGet]
        public async Task<IActionResult> GetAppraisee(string SearchQuery, string  OrderBy )
        {
            var aa = Request.Query;
            var result = await teamRepo.GetSupervisors(SearchQuery, OrderBy);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }


    }
}