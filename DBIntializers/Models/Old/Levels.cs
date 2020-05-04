using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Levels
    {
        public Levels()
        {
            CareerPaths = new HashSet<CareerPaths>();
            EmployeeLeaveByLevels = new HashSet<EmployeeLeaveByLevels>();
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int LevelNo { get; set; }
        public string LevelName { get; set; }
        public int EligibleYears { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual Groups Group { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<CareerPaths> CareerPaths { get; set; }
        public virtual ICollection<EmployeeLeaveByLevels> EmployeeLeaveByLevels { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
