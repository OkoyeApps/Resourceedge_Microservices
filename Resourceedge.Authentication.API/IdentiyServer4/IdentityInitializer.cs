using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.API.IdentiyServer4
{
    public class IdentityInitializer
    {
        public static void EnsureSeed(ConfigurationDbContext configDbContext, PersistedGrantDbContext persistDbContext)
        {
            if (persistDbContext != null && configDbContext != null)
            {
                //configDbContext.Database.EnsureDeleted();
                persistDbContext.Database.Migrate();
                configDbContext.Database.Migrate();

                if (!configDbContext.Clients.Any())
                {
                    foreach (var client in Configurations.GetClients())
                    {
                        configDbContext.Clients.Add(client.ToEntity());
                    }
                    configDbContext.SaveChanges();
                }

                if (!configDbContext.IdentityResources.Any())
                {
                    foreach (var resource in Configurations.GetIdentityResources())
                    {
                        configDbContext.IdentityResources.Add(resource.ToEntity());
                    }
                    configDbContext.SaveChanges();
                }

                if (!configDbContext.ApiResources.Any())
                {
                    foreach (var resource in Configurations.GetApiResources())
                    {
                        configDbContext.ApiResources.Add(resource.ToEntity());
                    }
                    configDbContext.SaveChanges();
                }
            }
        }
    }
}
