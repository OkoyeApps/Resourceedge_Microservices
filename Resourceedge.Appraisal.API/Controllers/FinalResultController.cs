using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Appraisal.Domain.Queries;
using System;
using System.IO;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resourceedge.Appraisal.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/finalResult")]
    public class FinalResultController : ControllerBase
    {
        private readonly IAppraisalFinalResult finalResultRepo;
        private readonly IMapper mapper;
        private readonly IAppraisalResult appraisalResult;
        private readonly IWebHostEnvironment hostingEnvironment;

        public FinalResultController(IAppraisalFinalResult _finalResult, IMapper _mapper, IAppraisalResult _appraisalResult, IWebHostEnvironment _hostingEnvironment)
        {
            finalResultRepo = _finalResult;
            mapper = _mapper;
            appraisalResult = _appraisalResult;
            hostingEnvironment = _hostingEnvironment;
        }
        [HttpGet("{cycleId}/{empId}")]
        public IActionResult GetEmployeeResult(string cycleId, int empId)
        {
            ObjectId CycleId = new ObjectId(cycleId);

            var result = finalResultRepo.GetEmployeeResult(empId, CycleId);
            var resultToReturn = mapper.Map<FinalResultDtoForView>(result);

            if (resultToReturn != null)
            {
                return Ok(resultToReturn);
            }

            return NoContent();
        }

        [HttpGet("{cycleId}")]
        public async Task<IActionResult> AllAppraisalResult([FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }

            var result = await finalResultRepo.GetAllResultByCycle(ObjectId.Parse(configParam.Cycle));
            if (result != null)
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpGet("~/api/Report")]
        public async Task<IActionResult> AllAppraisalResultByLocation([FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }

            var result = await finalResultRepo.GetAllResultByCycle(ObjectId.Parse(configParam.Cycle));
            if (result != null)
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpGet("~/api/Report/{group}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> AppraisalResultByGroup(string group, int pageNumber, int pageSize, [FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }

            var result = await finalResultRepo.GetAppraisalResultByGroup(group, pageNumber, pageSize, ObjectId.Parse(configParam.Cycle));
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("~/api/Report/Organisation/Count")]
        public async Task<IActionResult> GetOrganisation([FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }

            var result = await finalResultRepo.GetOrgaization(ObjectId.Parse(configParam.Cycle));
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }
        [HttpGet("recalculate")]
        public async Task<IActionResult> ReCalculateAppraisal([FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }

            var result = await finalResultRepo.ReCalculateFinalAppraisalResult(ObjectId.Parse(configParam.Cycle));
            if (result)
            {
                return Ok(result);
            }
            return NoContent();
        }
        [HttpGet("DownloadResult")]
        public async Task<IActionResult> DownloadResult([FromQuery]AppraisalQueryParam configParam)
        {
            var configDetails = await appraisalResult.GetAppraisalConfiguration(configParam.Config);
            if (configDetails == null)
            {
                return NotFound(new { message = "Appraisal configuration not found" });
            }


            string sWebRootFolder = $"{hostingEnvironment.ContentRootPath}/AppraisalResult";
            string sFileName = @$"Result_For_{configDetails.Name}.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();

                var result = await finalResultRepo.GetResultForDownload(ObjectId.Parse(configParam.Cycle));

                foreach (var item in result)
                {

                    ISheet excelSheet = workbook.CreateSheet(item.Key);
                    IRow row = excelSheet.CreateRow(0);

                    row.CreateCell(0).SetCellValue("SN");
                    row.CreateCell(1).SetCellValue("FullName");
                    row.CreateCell(2).SetCellValue("Email");
                    row.CreateCell(3).SetCellValue("EmployeeScore");
                    row.CreateCell(4).SetCellValue("AppraiserScore");
                    row.CreateCell(5).SetCellValue("FinalScore");
                    int count = 0;

                    foreach (var finalResult in item.Value)
                    {
                        row = excelSheet.CreateRow(++count);
                        row.CreateCell(0).SetCellValue(count);
                        row.CreateCell(1).SetCellValue(finalResult.EmployeeDetail.FullName);
                        row.CreateCell(2).SetCellValue(finalResult.EmployeeDetail.Email);
                        row.CreateCell(3).SetCellValue(finalResult.Result.EmployeeResult);
                        row.CreateCell(4).SetCellValue(finalResult.Result.AppraiseeResult.ToString());
                        row.CreateCell(5).SetCellValue(finalResult.Result.FinalResult.GetValueOrDefault());

                    }
                }
                workbook.Write(fs);
            }

            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
    }

}

