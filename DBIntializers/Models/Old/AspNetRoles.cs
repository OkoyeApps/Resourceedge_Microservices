using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            AppUserClaims = new HashSet<AppUserClaims>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int? GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public bool? Isdefault { get; set; }
        public bool? IsActive { get; set; }
        public int? LocationId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<AppUserClaims> AppUserClaims { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
