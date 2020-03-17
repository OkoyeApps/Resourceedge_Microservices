using Microsoft.AspNetCore.Mvc;
using Resourceedge.Appraisal.Domain.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ResultAreaController : ControllerBase
    {
        private readonly IDbContext ctx;

        public ResultAreaController(IDbContext _ctx)
        {
            ctx = _ctx;
        }

        public IActionResult Index()
        {
            var aa = ctx;
            return Ok(true);
        }

    }
}
