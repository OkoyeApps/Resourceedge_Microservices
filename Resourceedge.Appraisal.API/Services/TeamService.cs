using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Common.Archive;
using Resourceedge.Common.Util;
using Resourceedge.Worker.Auth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Services
{
    public class PeopleToAppraiseDto
    {
        public int EmployeeId { get; set; }
        public bool? HasApproved { get; set; }
    }
    public class TeamService : ITeamRepository
    {
        private readonly ILogger<TeamService> logger;
        private readonly HttpClient HttpClient;
        private readonly IQueryable<KeyResultArea> QueryableCollection;
        private readonly IKeyResultArea resultArea;
        private readonly ITokenAccesor tokenAccessor;
        private IMongoCollection<KeyResultArea> Collection;

        public TeamService(IHttpClientFactory _httpClientFactory, ILogger<TeamService> _logger, IDbContext _dbContext, IKeyResultArea _resultArea, ITokenAccesor _tokenAccessor)
        {
            if (_httpClientFactory != null && _logger != null && _dbContext != null)
            {
                HttpClient = _httpClientFactory.CreateClient("EmployeeService");
                this.logger = _logger;
                resultArea = _resultArea;
                Collection = _dbContext.Database.GetCollection<KeyResultArea>($"{nameof(KeyResultArea)}s");

                resultArea = _resultArea;
                tokenAccessor = _tokenAccessor;
                QueryableCollection = Collection.AsQueryable();
            }
            else
            {
                if (_httpClientFactory == null)
                {
                    throw new ArgumentNullException(nameof(_httpClientFactory));
                }
                throw new ArgumentNullException(nameof(logger));
            }
        }
        public async Task<IEnumerable<OldEmployeeDto>> GetEmployeesToAppraise(int employeeId)
        {
            var EmployeesToAppraise = QueryableCollection.Where(x => x.HodDetails.EmployeeId == employeeId).Select(x => x.EmployeeId.ToString()).Distinct().ToList();

            if (EmployeesToAppraise.Any())
            {
                return await FetchEmployeesDetailsFromEmployeeService(EmployeesToAppraise);
            }

            return new List<OldEmployeeDto>();
        }

        public async Task<IEnumerable<OldEmployeeDto>> GetEmployeesToApproveEPA(int employeeId, string type)
        {
            var EmployeesToAppraise = new List<PeopleToAppraiseDto>();
            if(string.IsNullOrEmpty(type) || type != "appraisal")
            {
                EmployeesToAppraise = QueryableCollection.Where(x => x.HodDetails.EmployeeId == employeeId).Select(x => new PeopleToAppraiseDto { EmployeeId = x.EmployeeId, HasApproved = x.Status.Hod }).ToList();
                EmployeesToAppraise = EmployeesToAppraise.Distinct(EdgeComparer.Get<PeopleToAppraiseDto>((x, y) => x.EmployeeId == y.EmployeeId && x.HasApproved == y.HasApproved , "EmployeeId")).ToList();
            }
            else
            {
                EmployeesToAppraise = QueryableCollection.Where(x => x.HodDetails.EmployeeId == employeeId || x.AppraiserDetails.EmployeeId == employeeId).Select(x => new PeopleToAppraiseDto { EmployeeId = x.EmployeeId, HasApproved = x.Status.Hod }).ToList();
            }
                

            if (EmployeesToAppraise.Any())
            {
                var distinctEmployees = GetDistinctEmployeeByApprovalStatus(EmployeesToAppraise);
                var returnedEmployees =  await FetchEmployeesDetailsFromEmployeeService(distinctEmployees.Select(x=>x.EmployeeId.ToString()));
                var transformedEmployee = returnedEmployees.Select(x => new EpaToApproveDto { Email = x.Email, EmployeeId = x.EmployeeId, FullName = x.FullName, Subgroup = x.Subgroup, UserId = x.UserId }).OrderBy(x=>x.FullName).ToList();
                foreach (var item in distinctEmployees)
                {
                    var employeedetail = transformedEmployee.Where(x => x.EmployeeId == item.EmployeeId).FirstOrDefault();
                    if(employeedetail != null && item.HasApproved != employeedetail.HasApproved && item.HasApproved != null)
                    {
                         employeedetail.HasApproved = item.HasApproved;
                    }
                    else if(employeedetail != null)
                    {
                        employeedetail.HasApproved = item.HasApproved;
                    }
                }

                return transformedEmployee;
            }
            return new List<OldEmployeeDto>();
        }


        private IEnumerable<PeopleToAppraiseDto> GetDistinctEmployeeByApprovalStatus(List<PeopleToAppraiseDto> employees)
        {
            List<PeopleToAppraiseDto> employeesToReturn = new List<PeopleToAppraiseDto>();

            foreach (var item in employees)
            {
                var existingEmployee = employeesToReturn.Where(x => x.EmployeeId == item.EmployeeId).FirstOrDefault();
                if (existingEmployee != null)
                {
                    if(item.HasApproved == true || item.HasApproved == false)
                    {
                        existingEmployee.HasApproved = item.HasApproved;
                    }
                }
                else
                {
                    employeesToReturn.Add(item);
                }
            }
            return employeesToReturn;
        }
   

        public async Task<IEnumerable<OldEmployeeDto>> FetchEmployeesDetailsFromEmployeeService(IEnumerable<string> Ids)
        {
            var response = await HttpClient.GetAsync($"/api/employeecollection/({string.Join(",", Ids)})");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<IEnumerable<OldEmployeeDto>>(content, options);

                return result;
            }
            return new List<OldEmployeeDto>();
        }


        public async Task<IEnumerable<AppraisalKeyResultAreaForViewDto>> GetTeamMemberKpi(int MyId, int TeammeberId)
        {
            //var result = resultArea.GetKeyResultAreasForAppraiser(MyId, TeammeberId);
            var year = DateTime.Now.Year;
            var result = QueryableCollection.Where(x => x.HodDetails.EmployeeId == MyId && x.EmployeeId == TeammeberId && x.Year == year);
            return await Task.FromResult(UpdateWhoAmIForList(result, MyId));
        }


        public IEnumerable<AppraisalKeyResultAreaForViewDto> UpdateWhoAmIForList(IEnumerable<KeyResultArea> resultArea, int employeeId)
        {
            var result = resultArea.Select(x =>
                new AppraisalKeyResultAreaForViewDto
                {
                    //whoami = x.AppraiserDetails.EmployeeId == employeeId ? "APPRAISER" : "HOD",
                    whoami = "HOD",
                    Approved = x.Approved,
                    EmployeeId = x.EmployeeId,
                    Name = x.Name,
                    Weight = x.Weight,
                    keyOutcomes = x.keyOutcomes,
                    Id = x.Id,
                    Status = x.Status,
                    Appraiser = x.AppraiserDetails,
                    HeadOfDepartment = x.HodDetails
                }
            );
            return result;
        }

        public async Task<IEnumerable<OldEmployeeForViewDto>> GetSupervisors(int empId, string searchParam, string orderParam)
        {
            HttpClient.SetBearerToken(tokenAccessor.TokenResponse.AccessToken);

            var response = await HttpClient.GetAsync($"api/employee/SearchEmployee/{empId}?SearchQuery={searchParam}&OrderBy={orderParam}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<IEnumerable<OldEmployeeForViewDto>>(content, options);

                return result;
            }

            return null;
        }

        public async Task<List<int>> GetEmployeeIDs()
        {
            HttpClient.SetBearerToken(tokenAccessor.TokenResponse.AccessToken);
            var response = await HttpClient.GetAsync($"api/employee");
            if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<IEnumerable<OldEmployeeForViewDto>>(content, options);

                return result.Select(x => x.EmployeeId).ToList();
            }
            return null;
        }

    }
}
