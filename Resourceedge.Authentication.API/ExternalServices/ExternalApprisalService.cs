using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Resourceedge.Authentication.Domain.Entities;
using Resourceedge.Authentication.Domain.Extensions;
using Resourceedge.Authentication.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.API.ExternalServices
{
    public class ExternalApprisalService : IExternalServiceInterface
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly EdgeDbContext context;
        private readonly ILogger<ExternalApprisalService> Logger;

        public ExternalApprisalService(SignInManager<ApplicationUser> _signInManager, UserManager<ApplicationUser> usermanager, EdgeDbContext _context, ILogger<ExternalApprisalService> logger)
        {
            this.UserManager = usermanager;
            context = _context;
        }

        public async Task<bool> AddMultipleUserClaimsByEmail(Dictionary<string, IEnumerable<Claim>> userClaims)
        {
            try
            {
                foreach (var singleUser in userClaims)
                {
                    var currentUser = await UserManager.FindByEmailAsync(singleUser.Key);
                    if (currentUser != null)
                    {
                        var result = await UserManager.AddMultipleEdgeClaimAsync(currentUser.Id, singleUser.Value, context);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex, "could not add user to role in authentication external service", new object[] { });
                return false;
            }
        }

    }
}