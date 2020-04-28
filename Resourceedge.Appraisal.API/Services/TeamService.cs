using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
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
            var EmployeesToAppraise = new List<string>();
            if(string.IsNullOrEmpty(type) || type != "appraisal")
            {
                EmployeesToAppraise =  QueryableCollection.Where(x => x.HodDetails.EmployeeId == employeeId).Select(x => x.EmployeeId.ToString()).Distinct().ToList();
            }
            else
            {
                EmployeesToAppraise = QueryableCollection.Where(x => x.HodDetails.EmployeeId == employeeId || x.AppraiserDetails.EmployeeId == employeeId).Select(x => x.EmployeeId.ToString()).Distinct().ToList();
            }
                

            if (EmployeesToAppraise.Any())
            {
                return await FetchEmployeesDetailsFromEmployeeService(EmployeesToAppraise);
            }
            return new List<OldEmployeeDto>();
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


        public async Task<IEnumerable<KeyResultAreaForViewDto>> GetTeamMemberKpi(int MyId, int TeammeberId)
        {
            //var result = resultArea.GetKeyResultAreasForAppraiser(MyId, TeammeberId);
            var year = DateTime.Now.Year;
            var result = QueryableCollection.Where(x => x.HodDetails.EmployeeId == MyId && x.EmployeeId == TeammeberId && x.Year == year);
            return UpdateWhoAmIForList(result, MyId);
        }


        public IEnumerable<KeyResultAreaForViewDto> UpdateWhoAmIForList(IEnumerable<KeyResultArea> resultArea, int employeeId)
        {
            var result = resultArea.Select(x =>
                new KeyResultAreaForViewDto
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

        public async Task<bool> GetEmployee(int empId)
        {
            HttpClient.SetBearerToken(tokenAccessor.TokenResponse.AccessToken);
            var response = await HttpClient.GetAsync($"api/employee/employeeId/{empId}");
            if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                return true;
            }
            return false;
        }

    }
}
