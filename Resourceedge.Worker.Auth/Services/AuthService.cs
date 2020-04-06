using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Resourceedge.Worker.Common.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Resourceedge.Worker.Auth.Services
{
    public class AuthService
    {

        public async Task<bool> AddUserClaimsByEmail(Dictionary<string, List<Claim>> UserAndClaims)
        {
            try
            {
                var dbContext = new EdgeUserDBContext();
                foreach (var item in UserAndClaims)
                {
                    var currentUser = dbContext.AspNetUsers.Include("AspNetUserClaims").FirstOrDefault(x => x.Email == item.Key);
                    if (currentUser != null)
                    {
                        dbContext.Update(currentUser);
                        foreach (var claim in item.Value)
                        {
                            var exisitingClaim = currentUser.AspNetUserClaims.FirstOrDefault(x => x.ClaimValue == claim.Value && x.ClaimType == claim.Type);
                            if (exisitingClaim == null)
                            {
                                currentUser.AspNetUserClaims.Add(new AspNetUserClaims() { ClaimType = claim.Type, ClaimValue = claim.Value, UserId = currentUser.Id });

                            }
                        }
                    }
                }
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        
        }
    }
}
