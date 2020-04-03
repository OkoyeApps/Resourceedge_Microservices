using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Resourceedge.Authentication.API.IdentiyServer4;
using Resourceedge.Authentication.Domain.Entities;
using Resourceedge.Authentication.Domain.Initializers;

namespace Resourceedge.Authentication.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var UserManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var EdgeDbContext = scope.ServiceProvider.GetRequiredService<EdgeDbContext>();
                var PersistedDbContext =  scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>();
                var ConfigurationdDbContext =  scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                //await EdgeUserInitializer.EnsureSeed(UserManager, EdgeDbContext);
                //IdentityInitializer.EnsureSeed(ConfigurationdDbContext, PersistedDbContext);
            }

                host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
