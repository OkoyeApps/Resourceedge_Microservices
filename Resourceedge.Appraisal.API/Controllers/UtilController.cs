using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Email.Api.Interfaces;
using Resourceedge.Email.Api.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IEmailSender emailSender;

        public UtilController(IKeyResultArea _resultArea, IAppraisalResult _appResult, IMapper _mapper, IEmailSender emailSender)
        {
            resultArea = _resultArea;
            this.appResult = _appResult;
            this.mapper = _mapper;
            this.emailSender = emailSender;
        }

        [Route("check/email/template/for/valid"), HttpGet]
        public async Task<IActionResult> CheckEmailTemplate()
        {
            var temp = Path.Combine(Directory.GetCurrentDirectory(), "EmailTemplate/emailTemplateScore.html");
            var fileInfo = new FileInfo(temp);
            var body = "";
            var bbbb = fileInfo.Directory;

           var htmlCOntent =   emailSender.FormatEmailAppraisalScore("Emmanuel", "2.5");

            SingleEmailDto email = new SingleEmailDto();
            email.ReceiverEmailAddress = "okoyeemma442@gmail.com";
            email.HtmlContent =  await htmlCOntent;
          var bbbbb =   await  emailSender.SendToSingleEmployee("Testing on Docker", email);
            //emailSender.HtmlContent = await sender.FormatEmail(employee.FullName, keyResultArea.AppraiserDetails.Name, msg, title, url);
            //if (fileInfo.Exists)
            //{
            //    using (StreamReader stream = new StreamReader(fileInfo.FullName))
            //    {
            //        body = await stream.ReadToEndAsync();
            //    }

            //}
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
                var result =await appResult.GetEmployeesToAppraise(employeeid, "5e8efe5806468b0001c0fc9b", "5e8efe5806468b0001c0fc9b", whoami);
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
