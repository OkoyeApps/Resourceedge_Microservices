using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Resourceedge.Common.Archive;
using Resourceedge.Employee.Domain.DbContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Resourceedge.Employee.API
{
    public class Initializer
    {
        public static void SeedEmployeeDb(IApplicationBuilder service)
        {
            var dbContext = service.ApplicationServices.GetRequiredService(typeof(IDbContext)) as IDbContext;
            if (dbContext != null)
            {
                var collection = dbContext.Database.GetCollection<Resourceedge.Common.Archive.OldEmployee>($"{nameof(OldEmployee)}s");
                if (!collection.AsQueryable().Any())
                {
                    var jsonString = File.ReadAllText("Employees.json");
                    var ParsedJson = JsonSerializer.Deserialize<IEnumerable<OldEmployee>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
                    collection.InsertMany(ParsedJson);

                }
            }
        }
    }
}
