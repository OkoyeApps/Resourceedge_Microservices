using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Common.Util;
using Resourceedge.Employee.Domain.ArchiveEntity;
using Resourceedge.Employee.Domain.DbContext;
using Resourceedge.Employee.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Resourceedge.Employee.API.Services
{
    public class ArchiveServices : IOldEmployee
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
    }
}
