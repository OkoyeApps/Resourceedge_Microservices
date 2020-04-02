using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class LineManager2
    {
        public LineManager2()
        {
            SupervisorEmployees = new HashSet<SupervisorEmployees>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int LocationId { get; set; }
        public string UserId { get; set; }
        public int UnitId { get; set; }
        public int? DepartmentId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual BusinessUnits Unit { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<SupervisorEmployees> SupervisorEmployees { get; set; }
    }
}
