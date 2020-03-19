using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Employee.Domain.DbContext
{
    public class EmployeeDbContext : IDbContext
    {
        public static EmployeeDbContext Create(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            EmployeeDbContext dbcontext = new EmployeeDbContext();
            dbcontext.Database = client.GetDatabase(dbName);
            return dbcontext;

        }
        public IMongoDatabase Database { get; set; }
    }
}
