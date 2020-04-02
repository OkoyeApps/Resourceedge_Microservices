using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.Domain.Entities
{
    public class ApplicationUser : IdentityUser<string>
    {
        private string _fullName;
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(_fullName))
                {
                    _fullName = $"{FirstName} {LastName}";
                }
                return _fullName;
            }
            set => _fullName = value;
        }
    }
}
