using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class ReportManagers
    {
        public ReportManagers()
        {
            LeaveManagements = new HashSet<LeaveManagements>();
        }

        public string ManagerUserId { get; set; }
        public int DepartmentId { get; set; }
        public int BusinessUnitId { get; set; }
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public int GroupId { get; set; }
        public int LocationId { get; set; }
        public int SubGroupId { get; set; }

        public virtual BusinessUnits BusinessUnit { get; set; }
        public virtual Departments Department { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<LeaveManagements> LeaveManagements { get; set; }
    }
}
