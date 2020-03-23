using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Common.Util;
using Resourceedge.Employee.API.Helpers;
using Resourceedge.Employee.Domain.Dtos;
using Resourceedge.Employee.Domain.Interfaces;
using Resourceedge.Common.Archive;

namespace Resourceedge.Employee.API.Controllers
{
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

        [HttpGet(Name = "GetAllEmployees")]
        public IActionResult GetEmployees([FromRoute] PaginationResourceParameter param)
        {
            var pagedEmployees = EmployeeRepo.GetEmployees(param);
            var paginationMetadata = new
            {
                totalCount = pagedEmployees.TotalCount,
                pageSize = pagedEmployees.PageSize,
                currentPage = pagedEmployees.CurrentPage,
                totalPages = pagedEmployees.TotalPages,
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));
            return Ok(mapper.Map<IEnumerable<OldEmployeeDto>>(pagedEmployees));
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

        [HttpGet("({Ids})")]
        public IActionResult GetMultipleEmployees ([FromRoute][ModelBinder(BinderType = typeof(ArrayModelBinder))] string Ids)
        {
            return Ok();
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

        [HttpGet("SearchEmployee")]
        public IActionResult GetEmployeeBySearch([FromQuery]PaginationResourceParameter resourceParameters)
        {
           var result = EmployeeRepo.GetEmployeesWithSeachQuery(resourceParameters);
            return Ok(result);
        }
        
    }
}