﻿using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Resourceedge.Authentication.Domain.Entities;
using Resourceedge.Authentication.Domain.Extensions;
using Resourceedge.Authentication.Domain.Interfaces;
using Resourceedge.Authentication.Domain.Model;
using Resourceedge.Email.Api.Interfaces;
using Resourceedge.Email.Api.Model;
using Resourceedge.Email.Api.SGridClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private readonly IEmailSender sender;

        public AuthServices(SignInManager<ApplicationUser> _signInManager, UserManager<ApplicationUser> usermanager,
            EdgeDbContext _context, ILogger<AuthServices> logger, ISGClient _client, IEmailSender _sender)
        {
            SignInManager = _signInManager;
            this.UserManager = usermanager;
            context = _context;
            this.Logger = logger;
            sender = _sender;
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

        public async Task<(bool, string)> GetUserbyEmailAsync(string email)
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

            var result = await SignInManager.PasswordSignInAsync(currentuser.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                return (result.Succeeded, "sign in successful");
            }
            return (false, "Email or password incorrect");
        }

        public async Task<(bool, ApplicationUser, string)> GetResetPasswordToken(string email)
        {
            try
            {
                var currentUser = await UserManager.FindByEmailAsync(email);
                if (currentUser == null)
                {
                    return (false, null, "Email does not exist, kindly see your HR for registration");
                }

                var token = await UserManager.GeneratePasswordResetTokenAsync(currentUser);


                return (true, currentUser, token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<(bool, string)> SendResetPasswordEmail(ApplicationUser currentUser, string url)
        {
            try
            {
                string subject = "Reset Password";
                SingleEmailDto emailDto = new SingleEmailDto()
                {
                    ReceiverEmailAddress = currentUser.Email,
                    ReceiverFullName = currentUser.FullName,
                    HtmlContent = await sender.FormatEmail(currentUser.FirstName, url)
                };

                if (emailDto.HtmlContent == null)
                {
                    emailDto.HtmlContent = url;
                }
                var res = await sender.SendToSingleEmployee(subject, emailDto);
                if (res == HttpStatusCode.Accepted)
                    return (true, res.ToString());
                else
                    return (false, res.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> ResetUserPassword(ResetPasswordViewModel model)
        {
            try
            {
                var currentUser = await UserManager.FindByEmailAsync(model.Email);
                if (currentUser == null)
                {
                    return (false);
                }

                var res = await UserManager.ResetPasswordAsync(currentUser, model.Token, model.Password);
                if (res.Succeeded)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> LogoutUser()
        {
            await SignInManager.SignOutAsync();
            return await Task.FromResult(true);
        }
    }
}
