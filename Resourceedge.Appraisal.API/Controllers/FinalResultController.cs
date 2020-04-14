using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.Models;

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

        public FinalResultController(IAppraisalFinalResult _finalResult, IMapper _mapper)
        {
            finalResultRepo = _finalResult;
            mapper = _mapper;
        }
        [HttpGet("{cycleId}/{empId}")]
        public IActionResult GetEmployeeResult(string cycleId, int empId)
        {
            ObjectId CycleId = new ObjectId(cycleId);

            var result = finalResultRepo.GetEmployeeResult(empId, CycleId);
            var resultToReturn = mapper.Map<FinalResultDtoForView>(result);

            return Ok(resultToReturn);
        }



    }
}
