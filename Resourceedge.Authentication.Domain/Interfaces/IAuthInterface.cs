﻿using Resourceedge.Authentication.Domain.Entities;
using Resourceedge.Authentication.Domain.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.Domain.Interfaces
{
    public interface IAuthInterface
    {
        Task<(bool, string)> GetUserbyEmailAsync(string email);
        Task<(bool, string)> Login(LoginViewModel model);
        Task<(bool, string)> AddClaimToUser(string userId, IEnumerable<Claim> claims);
        Task<(bool, ApplicationUser, string)> GetResetPasswordToken(string email);
        Task<(bool, string)> SendResetPasswordEmail(ApplicationUser currentUser, string url);
        Task<bool> ResetUserPassword(ResetPasswordViewModel model);
        public Task<bool> LogoutUser();
    }
}
