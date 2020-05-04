using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class EmployeeConfigurations
    {
        public EmployeeConfigurations()
        {
            EmployeeUnitDepartments = new HashSet<EmployeeUnitDepartments>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int? LocationId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<EmployeeUnitDepartments> EmployeeUnitDepartments { get; set; }
    }
}
