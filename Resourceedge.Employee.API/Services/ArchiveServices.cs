using AutoMapper;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Common.Archive;
using Resourceedge.Common.Models;
using Resourceedge.Common.Util;
using Resourceedge.Employee.Domain.DbContext;
using Resourceedge.Employee.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Resourceedge.Employee.API.Services
{
    public class ArchiveServices : IEmployee
    {
        private readonly ILogger<ArchiveServices> logger;
        private readonly HttpClient HttpClient;
        private readonly IMongoCollection<OldEmployee> Collection;
        private readonly IQueryable<OldEmployee> QueryableCollection;
        private readonly IMapper mapper;

        public ArchiveServices(IHttpClientFactory _httpClientFactory, ILogger<ArchiveServices> _logger, IDbContext _dbContext, IMapper _mapper)
        {
            if (_httpClientFactory != null && _logger != null && _dbContext != null)
            {
                HttpClient = _httpClientFactory.CreateClient("OldEdge");
                this.logger = _logger;
                Collection = _dbContext.Database.GetCollection<OldEmployee>($"{nameof(OldEmployee)}s");
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

            mapper = _mapper;
        }

        public OldEmployee GetEmployeeByEmail(string email)
        {
            return QueryableCollection.FirstOrDefault(x => x.EmpEmail == email);
        }

        public OldEmployee GetEmployeeByEmployeeId(int employeeId)
        {
            return QueryableCollection.FirstOrDefault(x => x.EmployeeId == employeeId);
        }

        public OldEmployee GetEmployeeByObjectId(ObjectId Id)
        {
            return Collection.Find(Builders<OldEmployee>.Filter.Eq("_Id", Id)).FirstOrDefault();
        }

        public OldEmployee GetEmployeeByUserId(string userId)
        {
            return QueryableCollection.FirstOrDefault(x => x.UserId == userId);
        }

        public PagedList<OldEmployee> GetEmployees(PaginationResourceParameter param)
        {
            var paginatedList = PagedList<OldEmployee>.Create(QueryableCollection, param.PageNumber, param.PageSize);
            return paginatedList;
        }

        public async Task<IEnumerable<OldEmployee>> GetMultipleEmployeesById(IEnumerable<int> Ids)
        {
            var filter = Builders<OldEmployee>.Filter.In("EmployeeId", Ids);
            var result = await Collection.Find(filter).ToListAsync();
            return result;
        }

        public PagedList<NameEmailWithFullName> GetEmployeesWithSeachQuery(int empId, PaginationResourceParameter resourceParam)
        {

            var list = QueryableCollection.Where(SearchPredicate(empId, resourceParam.SearchQuery))
                                          .Select(a => new NameEmailWithFullName() { Email = a.EmpEmail, FullName = a.FullName, EmployeeId = a.EmployeeId }).AsQueryable();
            var pagedList = PagedList<NameEmailWithFullName>.Create(list, resourceParam.PageNumber, resourceParam.PageSize);

            return pagedList;
        }


        private Func<OldEmployee, bool> SearchPredicate(int empId, string SearchQuery)
        {
            return e => (e.FullName.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) || e.EmpEmail.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
            && (e.EmployeeId != empId && e.Isactive == true);
            
        }

        public async Task Insert(OldEmployee employee)
        {
            await Collection.InsertOneAsync(employee);
        }

        public async Task<bool> AddNewEmployeeByEmail(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return false;
                }

                var emp = GetEmployeeByEmail(email);
                if (emp != null)
                {
                    return false;
                }

                var response = await HttpClient.GetAsync($"/api/settings/GetEmployeeByEmail/{email}/");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<OldEmployeeDtoForCreate>(content, options);

                    var EmployeeToAdd = mapper.Map<OldEmployee>(result);

                    await Insert(EmployeeToAdd);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }

        public async Task<bool> AddMultipleEmployeeByEmail(IList<string> emails)
        {
            try
            {
                if (!emails.Any())
                {
                    return false;
                }

                foreach (var email in emails)
                {
                    await AddNewEmployeeByEmail(email);
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }        
        }

    }
}
