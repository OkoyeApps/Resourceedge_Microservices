using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class AspNetUserRoles
    {
        public string RoleId { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public int? LocationId { get; set; }
        public int? EmployeeUnitDepartmentId { get; set; }

        public virtual EmployeeUnitDepartments EmployeeUnitDepartment { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual AspNetRoles Role { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
