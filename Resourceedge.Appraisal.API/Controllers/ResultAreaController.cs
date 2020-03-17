using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.API.Services;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    [Route("api/resultarea")]
    public class ResultAreaController : ControllerBase
    {
        private readonly IKeyResultArea resultArea;

        public ResultAreaController(IKeyResultArea _resultArea)
        {
            this.resultArea = _resultArea;
        }

        public async Task<IActionResult> Index(int? pageSize, int pageNumber)
        {

            var data = await resultArea.Get(pageSize, pageNumber);           
            return Ok(data);
        }
     
        public async Task<IActionResult> Edit()
        {
            return Ok();
        }

    }
}
