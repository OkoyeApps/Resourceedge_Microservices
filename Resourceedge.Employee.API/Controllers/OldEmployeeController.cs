using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Common.Archive;
using Resourceedge.Common.Util;
using Resourceedge.Employee.API.Helpers;
using Resourceedge.Employee.Domain.Dtos;
using Resourceedge.Employee.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Employee.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/employee")]
    public class OldEmployeeController : ControllerBase
    {
        private readonly IEmployee EmployeeRepo;
        private readonly IMapper mapper;

        public OldEmployeeController(IEmployee _oldEmployee, IMapper _mapper)
        {
            EmployeeRepo = _oldEmployee;
            mapper = _mapper;
        }


        [HttpGet("{email}", Name = "GetEmployeeByEmail")]
        public IActionResult GetEmployeeByEmail(string email)
        {
            return Ok(mapper.Map<OldEmployeeDto>(EmployeeRepo.GetEmployeeByEmail(email)));
        }

        [HttpGet("new/{Id}", Name = "GetEmployeeById")]
        public IActionResult GetEmployeeById(string Id)
        {
            return Ok(mapper.Map<OldEmployeeDto>(EmployeeRepo.GetEmployeeByObjectId(new ObjectId(Id))));
        }


        [HttpGet("employeeId/{Id}", Name = "GetEmployeeByEmployeeId")]
        public IActionResult GetEmployeeByEmployeeId(int Id)
        {

            return Ok(mapper.Map<OldEmployeeDto>(EmployeeRepo.GetEmployeeByEmployeeId(Id)));
        }

        [HttpGet("userid/{Id}", Name = "GetEmployeeByUserId")]
        public IActionResult GetEmployeeByUserId(string Id)
        {
            return Ok(mapper.Map<OldEmployeeDto>(EmployeeRepo.GetEmployeeByUserId(Id)));
        }
        
        private IEnumerable<LinkDto> CreateLinksForEmployees(EmployeeResourceParameter employeeResourceParameters, bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>();
            //self
            links.Add(new LinkDto(ResourceUriGenerator.CreateAuthorResourceUri(employeeResourceParameters, ResourceUriType.Current, Url), "AllEmployee", "GET"));

            if (hasNext)
            {
                links.Add(new LinkDto(ResourceUriGenerator.CreateAuthorResourceUri(employeeResourceParameters, ResourceUriType.NextPage, Url), "nextPage", "GET"));
            }
            if (hasNext)
            {
                links.Add(new LinkDto(ResourceUriGenerator.CreateAuthorResourceUri(employeeResourceParameters, ResourceUriType.PreviousPage, Url), "previousPage", "GET"));
            }


            return links;
        }

        [HttpGet("SearchEmployee/{empId:int}")]
        public IActionResult GetEmployeeBySearch(int empId, [FromQuery]PaginationResourceParameter resourceParameters)
        {
            var result = EmployeeRepo.GetEmployeesWithSeachQuery(empId, resourceParameters);
            return Ok(result);
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddNewEmployee(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return BadRequest();
            }

            var res = await EmployeeRepo.AddNewEmployeeByEmail(Email);
            if (!res)
            {
                return BadRequest();
            }

            return Ok();

            //return CreatedAtRoute("GetEmployeeByEmail", new { email = Email });
        }

        [HttpPost("AddEmployees")]
        public async Task<IActionResult> AddNewEmployees(IList<string> Emails)
        {
            if (!Emails.Any())
            {
                return BadRequest();
            }

            var res = await EmployeeRepo.AddMultipleEmployeeByEmail(Emails);
            if (!res)
            {
                return BadRequest();
            }

            return Ok();
        }
        [HttpGet]
        public IActionResult AllEmployee()
        {
            var result = EmployeeRepo.GetEmployees();

            return Ok(result);
        }
    }
}