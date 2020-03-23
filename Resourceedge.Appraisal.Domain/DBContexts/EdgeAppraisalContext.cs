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
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
           


            var client = new MongoClient(connectionString);
            EdgeAppraisalContext dbcontext = new EdgeAppraisalContext();
            dbcontext.Database = client.GetDatabase(dbName);

            return dbcontext;

        }


        public IMongoDatabase Database { get; set; }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return Database.GetCollection<T>(collectionName);
        }
    }
}
