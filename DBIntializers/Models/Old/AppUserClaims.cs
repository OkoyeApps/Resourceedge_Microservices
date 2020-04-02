using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class AppUserClaims
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int ClaimId { get; set; }
        public string RoleId { get; set; }
        public int SubGroupId { get; set; }
        public int? GroupId { get; set; }
        public int? LocationId { get; set; }
        public int? EmployeeUnitDepartmentId { get; set; }
        public bool? IsActive { get; set; }

        public virtual AspNetUsers AppUser { get; set; }
        public virtual SystemClaims Claim { get; set; }
        public virtual EmployeeUnitDepartments EmployeeUnitDepartment { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual AspNetRoles Role { get; set; }
        public virtual SubGroups SubGroup { get; set; }
    }
}
