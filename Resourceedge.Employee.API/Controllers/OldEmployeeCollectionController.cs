using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Resourceedge.Common.Archive;
using Resourceedge.Common.Util;
using Resourceedge.Employee.API.Helpers;
using Resourceedge.Employee.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Resourceedge.Employee.API.Controllers
{
    [ApiController]
    [Route("api/employeecollection")]
    public class OldEmployeeCollectionController : ControllerBase
    {
        private readonly IEmployee EmployeeRepo;
        private readonly IMapper mapper;

        public OldEmployeeCollectionController(IEmployee _oldEmployee, IMapper _mapper)
        {
            EmployeeRepo = _oldEmployee;
            mapper = _mapper;
        }

        [HttpGet(Name = "GetAllEmployees")]
        public IActionResult GetEmployees([FromQuery] PaginationResourceParameter param)
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

        [HttpGet("({Ids})")]
        public async Task<IActionResult> GetMultipleEmployees([FromRoute][ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> Ids)
        {
            var resultFromRepo = await EmployeeRepo.GetMultipleEmployeesById(Ids);
            var resultForView = mapper.Map<IEnumerable<Common.Archive.OldEmployeeDto>>(resultFromRepo);
            return Ok(resultForView);
        }
    }
}
