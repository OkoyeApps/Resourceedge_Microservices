using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.DBContexts
{
   public  interface IDbContext
    {
        IMongoDatabase Database { get; set; }
    }
}
