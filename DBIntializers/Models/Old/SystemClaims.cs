using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class SystemClaims
    {
        public SystemClaims()
        {
            AppUserClaims = new HashSet<AppUserClaims>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<AppUserClaims> AppUserClaims { get; set; }
    }
}
