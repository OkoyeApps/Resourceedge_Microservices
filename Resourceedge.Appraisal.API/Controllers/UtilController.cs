using Microsoft.AspNetCore.Mvc;
using Resourceedge.Appraisal.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    public class UtilController : ControllerBase
    {


        private readonly IKeyResultArea resultArea;

        public UtilController(IKeyResultArea _resultArea)
        {
            resultArea = _resultArea;
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
    }
}
