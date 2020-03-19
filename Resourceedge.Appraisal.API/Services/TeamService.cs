using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Common.Archive;
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
        private IMongoCollection<KeyResultArea> Collection;

        public TeamService(IHttpClientFactory _httpClientFactory, ILogger<TeamService> _logger, IDbContext _dbContext, IKeyResultArea _resultArea)
        {
            if (_httpClientFactory != null && _logger != null && _dbContext != null)
            {
                HttpClient = _httpClientFactory.CreateClient("EmployeeService");
                this.logger = _logger;
                resultArea = _resultArea;
                Collection = _dbContext.Database.GetCollection<KeyResultArea>($"{nameof(KeyResultArea)}s");
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

            resultArea = _resultArea;
        }
        public async Task<IEnumerable<OldEmployeeDto>> GetEmployeesToAppraise(int employeeId)
        {
            var EmployeesToAppraise = QueryableCollection.Where(x => x.AppraiserDetails.EmployeeId == employeeId || x.HodDetails.EmployeeId == employeeId).Select(x => x.EmployeeId).Distinct().ToList();

            if (EmployeesToAppraise.Any())
            {
                var AA = string.Join(",", EmployeesToAppraise.Select(X => X));
                //Make Http Request to the Employee Service to fetch employees
                var response = await HttpClient.GetAsync($"/api/employeecollection/({string.Join(",", EmployeesToAppraise.Select(X => X))})");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<OldEmployeeDto>>(content, options);

                    return result;
                }
            }
            return new List<OldEmployeeDto>();
        }

        public async  Task<IEnumerable<KeyResultAreaForViewDto>> GetTeamMemberKpi(int MyId, int TeammeberId)
        {
            var result = resultArea.GetKeyResultAreasForAppraiser(MyId, TeammeberId);
            return UpdateWhoAmIForList(result, MyId); 
        }


        public IEnumerable<KeyResultAreaForViewDto> UpdateWhoAmIForList(IEnumerable<KeyResultArea> resultArea, int employeeId)
        {
            var result = resultArea.Select(x =>
                new KeyResultAreaForViewDto
                {
                    whoami = x.AppraiserDetails.EmployeeId == employeeId ? "APPRAISAL" : "HOD",
                    Approved = x.Approved,
                    EmployeeId = x.EmployeeId,
                    Name = x.Name,
                    Weight = x.Weight,
                    keyOutcomes = x.keyOutcomes,
                }
            );
            return result;
        }
    }
}
