using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Resourceedge.Authentication.Domain.Entities
{
    public class EdgeDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public EdgeDbContext(DbContextOptions<EdgeDbContext> options) : base(options)
        {

        }
    }


    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EdgeDbContext>
    {
        public EdgeDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../Resourceedge.Authentication.API/appsettings.Development.json").Build();
            var builder = new DbContextOptionsBuilder<EdgeDbContext>();
            var connectionString = configuration.GetConnectionString("Auth");
            builder.UseSqlServer(connectionString);
            return new EdgeDbContext(builder.Options);
        }
    }

}
