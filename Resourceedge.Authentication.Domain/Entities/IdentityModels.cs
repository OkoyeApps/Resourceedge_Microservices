using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.Domain.Entities
{

    // You will not likely need to customize there, but it is necessary/easier to create our own 
    // project-specific implementations, so here they are:
    public class ApplicationUserToken : IdentityUserToken<string>
    {
    }

    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
    }

    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        //public string SystemID { get; set; }
    }
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
    }
    public class ApplicationUserRole : IdentityUserRole<string>
    {
    }



    // Most likely won't need to customize these either, but they were needed because we implemented
    // custom versions of all the other types:
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, EdgeDbContext>
    {
        public ApplicationUserStore(EdgeDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }

    public class ApplicationRoleStore : RoleStore<ApplicationRole>
    {
        public ApplicationRoleStore(EdgeDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }







}
