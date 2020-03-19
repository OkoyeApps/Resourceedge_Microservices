using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Employee.Domain.DbContext
{
    public interface IDbContext
    {
        IMongoDatabase Database { get; set; }
    }
}
