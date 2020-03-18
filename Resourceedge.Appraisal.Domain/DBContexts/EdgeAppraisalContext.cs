using MongoDB.Driver;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Resourceedge.Appraisal.Domain.DBContexts
{
    public class EdgeAppraisalContext : IDbContext
    {
        public static EdgeAppraisalContext Create(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            EdgeAppraisalContext dbcontext = new EdgeAppraisalContext();
            dbcontext.Database = client.GetDatabase(dbName);

            return dbcontext;

        }


        public IMongoDatabase Database { get; set; }
    }
}
