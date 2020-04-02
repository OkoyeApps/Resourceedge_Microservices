using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resourceedge.Authentication.Domain.Entities;
using Resourceedge.Authentication.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.Domain.Extensions
{
    public static class UserManagerExtension
    {
        /// <summary>
        /// This is a extension method for adding claim in the Edge Authentication subsystem.
        /// Use this methdd to provide claim that targets a specific sub-system in the microservice.
        /// </summary>
        /// <typeparam name="TUser"></typeparam>
        /// <typeparam name="TContent"></typeparam>
        /// <param name="UserManager"></param>
        /// <param name="User"></param>
        /// <param name="claim"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task AddClaimAsync(this UserManager<ApplicationUser> UserManager, ApplicationUser User, Claim claim, EdgeDbContext context)
        {
            if (User == null)
            {
                throw new ArgumentNullException(nameof(User));
            }
            var currentUser = await UserManager.FindByEmailAsync(User.Email);
            if (currentUser == null)
            {
                //consider wether i should throw and error here or silently return without doing anything
                //throw new ArgumentNullException(nameof(User));
                return;
            }
            //context.UserClaims.Add(new ApplicationUserClaim { ClaimType = claim.Type, ClaimValue = claim.Value, SystemID = claim.SystemID, UserId = currentUser.Id });

            await UserManager.AddClaimAsync(currentUser, claim);

            //context.SaveChanges();
        }

        public static async Task<bool>  ClaimsExistForUser (this UserManager<ApplicationUser> UserManager, string userId, System.Security.Claims.Claim claim, EdgeDbContext context)
        {
            var user = await  UserManager.FindByIdAsync(userId);
            if(user == null)
            {
                throw new ArgumentNullException();
            }

            var hasClaim = context.UserClaims.Any(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);

            return hasClaim;
        }

        public static async Task<bool> AddMultipleEdgeClaimAsync(this UserManager<ApplicationUser> UserManager, string userId, IEnumerable<System.Security.Claims.Claim> claims,EdgeDbContext dbContext)
        {
            var user = await UserManager.FindByIdAsync(userId);
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            foreach (var claim in claims)
            {
                var hasclaim = await UserManager.ClaimsExistForUser(userId, claim, dbContext);
                if (!hasclaim)
                {
                   await UserManager.AddClaimAsync(user, claim);
                }
            }
            return true;
        }
    }
}
