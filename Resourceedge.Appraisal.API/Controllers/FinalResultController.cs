using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resourceedge.Appraisal.API.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resourceedge.Appraisal.API.Controllers
{
    [Authorize]
    [ApiController]
    public class FinalResultController : ControllerBase
    {
        private readonly IAppraisalFinalResult finalResultRepo;

        public FinalResultController(IAppraisalFinalResult _finalResult)
        {
            finalResultRepo = _finalResult;
        }

        

    }
}
