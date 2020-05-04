using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class EmployeeUnitDepartments
    {
        public EmployeeUnitDepartments()
        {
            AppUserClaims = new HashSet<AppUserClaims>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? LocationId { get; set; }
        public int? GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public int? UnitId { get; set; }
        public int DepartmentId { get; set; }
        public string UserId { get; set; }
        public int? TeamId { get; set; }
        public int EmployeeConfigurationId { get; set; }
        public bool? IsPrimary { get; set; }
        public bool? InGroupTeam { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual EmployeeConfigurations EmployeeConfiguration { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual Teams Team { get; set; }
        public virtual BusinessUnits Unit { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<AppUserClaims> AppUserClaims { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
