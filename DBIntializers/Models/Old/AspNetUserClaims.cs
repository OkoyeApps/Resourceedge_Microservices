using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class AspNetUserClaims
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string AppUserId { get; set; }

        public virtual AspNetUsers AppUser { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
