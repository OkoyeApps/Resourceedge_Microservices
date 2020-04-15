using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    [Route("api/util")]
    public class UtilController : ControllerBase
    {


        private readonly IKeyResultArea resultArea;
        private readonly IAppraisalResult appResult;
        private readonly IMapper mapper;

        public UtilController(IKeyResultArea _resultArea, IAppraisalResult _appResult, IMapper _mapper)
        {
            resultArea = _resultArea;
            this.appResult = _appResult;
            this.mapper = _mapper;
        }

        [Route("check/email/template/for/valid"), HttpGet]
        public async Task<IActionResult> CheckEmailTemplate()
        {
            //var temp = Path.Combine(Directory.GetCurrentDirectory(), "EmailTemplate\\AppraisalNotification.html");
            //var fileInfo = new FileInfo(temp);
            //var body = "";
            ////if (fileInfo.Exists)
            ////{
            ////    using (StreamReader stream = new StreamReader(fileInfo.FullName))
            ////    {
            ////        body = await stream.ReadToEndAsync();
            ////    }

            ////}
            //resultArea.SendApprovalNotification(new List<KeyResultArea> { new KeyResultArea { EmployeeId = 194, HodDetails = new NameEmail { Email = "c.okoye@genesystechhub.com" } } });


            //var result = await resultArea.GetAllSupervisorsForClaims();


            return Ok();

        }

        [Route("getemployeetoappraise/{employeeid}/{whoami}")]
        [HttpGet]
        public async Task<IActionResult> Check(int employeeid, string whoami)
        {
            try
            {
                var result =await appResult.GetEmployeesToAppraise(employeeid, whoami);
                var Dto = mapper.Map<IEnumerable<AppraisalForApprovalViewDto>>(result);
                return Ok(Dto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
