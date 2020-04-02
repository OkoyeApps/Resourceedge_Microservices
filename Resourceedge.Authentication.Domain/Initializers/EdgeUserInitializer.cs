using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Resourceedge.Authentication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Resourceedge.Authentication.Domain.Extensions;

namespace Resourceedge.Authentication.Domain.Initializers
{
    public class EdgeUserInitializer
    {

        public static async Task EnsureSeed(UserManager<ApplicationUser> UserManager, EdgeDbContext context)
        {
      
            if (context != null && UserManager != null)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();
                await Initialize(UserManager, context);
            }
            else
            {
                throw new ArgumentNullException(nameof(EdgeDbContext));
            }
        }

        private static async Task Initialize(UserManager<ApplicationUser> UserManager, EdgeDbContext context)
        {
            if (!context.Users.Any() && UserManager != null)
            {

                var user1 = new ApplicationUser { FirstName = "John", Email = "seed1@test.com", LastName = "Bob", UserName = "seed1@test.com" };
                var user2 = new ApplicationUser { FirstName = "Michael", Email = "seed2@test.com", LastName = "Mayor", UserName = "seed2@test.com" };

                await UserManager.CreateAsync(user1,"password");
                await UserManager.CreateAsync(user2, "password");

                await UserManager.AddClaimAsync(user1, new Claim("privilege_appraisal", "appraiser"));
                await UserManager.AddClaimAsync(user1, new Claim("privilege_appraisal", "hr"));
                await UserManager.AddClaimAsync(user1, new Claim("privilege_appraisal", "hod"));
              var result =   await UserManager.AddClaimAsync(user1, new Claim("privilege_appraisal", "hod"));

                await UserManager.AddClaimAsync(user2, new Claim("privilege_appraisal", "appraiser"));
                await UserManager.AddClaimAsync(user2, new Claim("privilege_appraisal", "hr"));

            }
        }
    }
}
