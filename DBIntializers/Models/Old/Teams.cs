using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Teams
    {
        public Teams()
        {
            EmployeeTeams = new HashSet<EmployeeTeams>();
            EmployeeUnitDepartments = new HashSet<EmployeeUnitDepartments>();
            TeamHeads = new HashSet<TeamHeads>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public int? LocationId { get; set; }
        public int? BusinessUnitId { get; set; }
        public int? DepartmentId { get; set; }
        public string Name { get; set; }
        public string TeamCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsGroupTeam { get; set; }

        public virtual BusinessUnits BusinessUnit { get; set; }
        public virtual Departments Department { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<EmployeeTeams> EmployeeTeams { get; set; }
        public virtual ICollection<EmployeeUnitDepartments> EmployeeUnitDepartments { get; set; }
        public virtual ICollection<TeamHeads> TeamHeads { get; set; }
    }
}
