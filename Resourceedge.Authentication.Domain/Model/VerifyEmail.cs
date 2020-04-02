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
}
