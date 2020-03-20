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
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };



            var client = new MongoClient(connectionString);
            EmployeeDbContext dbcontext = new EmployeeDbContext();
            dbcontext.Database = client.GetDatabase(dbName);
            return dbcontext;

        }
        public IMongoDatabase Database { get; set; }
    }
}
