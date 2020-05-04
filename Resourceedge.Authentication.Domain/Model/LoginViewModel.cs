using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Resourceedge.Authentication.Domain.Model
{
    
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email Addredd is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password is requied")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public string Name { get; set; }
    }

    public class LoginGetViewModel
    {
        public string UserName { get; set; }
        public string ReturnUrl { get; set; }
        public string Name { get; set; }
    }
}
