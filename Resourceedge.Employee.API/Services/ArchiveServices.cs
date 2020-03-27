using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Common.Archive;
using Resourceedge.Common.Util;
using Resourceedge.Employee.Domain.DbContext;
using Resourceedge.Employee.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Resourceedge.Employee.API.Services
{
    public class ArchiveServices : IEmployee
    {
        private readonly ILogger<ArchiveServices> logger;
        private readonly HttpClient HttpClient;
        private readonly IMongoCollection<OldEmployee> Collection;
        private readonly IQueryable<OldEmployee> QueryableCollection;

        public ArchiveServices(IHttpClientFactory _httpClientFactory, ILogger<ArchiveServices> _logger, IDbContext _dbContext)
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
            var result = await Collection.Find(filter).ToListAsync() ;
            return result;
        }

        public PagedList<OldEmployeeForViewDto> GetEmployeesWithSeachQuery(int empId, PaginationResourceParameter resourceParam)
        {

            var list = QueryableCollection.Where(e => e.FullName.Contains(resourceParam.SearchQuery) || e.EmpEmail.Contains(resourceParam.SearchQuery) && e.EmployeeId != empId)
                                          .Select(a => new OldEmployeeForViewDto() { Email = a.EmpEmail, FullName = a.FullName, EmployeeId = a.EmployeeId });
            var pagedList = PagedList<OldEmployeeForViewDto>.Create(list, resourceParam.PageNumber, resourceParam.PageSize);

            return pagedList;
        }
    }
}
