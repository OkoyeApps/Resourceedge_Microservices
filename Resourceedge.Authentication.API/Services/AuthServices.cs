using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Resourceedge.Authentication.Domain.Entities;
using Resourceedge.Authentication.Domain.Extensions;
using Resourceedge.Authentication.Domain.Interfaces;
using Resourceedge.Authentication.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.API.Services
{
    public class AuthServices : IAuthInterface
    {
        private readonly SignInManager<ApplicationUser> SignInManager;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly EdgeDbContext context;
        private readonly ILogger<AuthServices> Logger;

        public AuthServices(SignInManager<ApplicationUser> _signInManager, UserManager<ApplicationUser> usermanager, EdgeDbContext _context, ILogger<AuthServices> logger)
        {
            SignInManager = _signInManager;
            this.UserManager = usermanager;
            context = _context;
            this.Logger = logger;
        }

        public async Task<(bool, string)> AddClaimToUser(string userId, IEnumerable<System.Security.Claims.Claim> claims)
        {
            var result = await UserManager.AddMultipleEdgeClaimAsync(userId, claims, context);
            if (!result)
            {
                return (false, "current specified user does not exist");
            }

            return (true, "claim(s) added for user");
        }

        public async Task<(bool, string)> GetUserbyEmail(string email)
        {
            try
            {
                var currentUser = await UserManager.FindByEmailAsync(email);
                if (currentUser == null)
                {
                    return (false, "Email does not exist, kindly see your HR for registration");
                }
                return (true, currentUser.FirstName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<(bool, string)> Login(LoginViewModel model)
        {
            var currentuser = await UserManager.FindByEmailAsync(model.UserName);
            if (currentuser == null)
            {
                return (false, "Email or password incorrect");
            }
              
            var result = await SignInManager.PasswordSignInAsync(currentuser.UserName,model.Password,false, false);
            if (result.Succeeded)
            {
                return (result.Succeeded, "sign in successful");
            }
            return (false, "Email or password incorrect");
        }
    }
}
