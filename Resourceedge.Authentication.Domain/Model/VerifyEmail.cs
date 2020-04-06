using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Resourceedge.Authentication.Domain.Model
{
   public  class VerifyEmail
    {
        [Required(ErrorMessage="Email is required")]
        public string Email { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class ResetPasswordViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
        public string ReturnUrl { get; set; }
    }
}
