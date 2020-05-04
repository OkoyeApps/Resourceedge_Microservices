using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class DepartmentalSkills
    {
        public DepartmentalSkills()
        {
            EmployeeSkills = new HashSet<EmployeeSkills>();
        }

        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public int? BusinessUnitId { get; set; }
        public int? DepartmentId { get; set; }
        public string CreatedbyRole { get; set; }
        public string CreatedbyGroup { get; set; }
        public string ModifiedbyRole { get; set; }
        public string ModifiedbyGroup { get; set; }
        public string SkillName { get; set; }
        public string Description { get; set; }
        public string Createdby { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Isactive { get; set; }
        public bool? Isused { get; set; }

        public virtual BusinessUnits BusinessUnit { get; set; }
        public virtual Departments Department { get; set; }
        public virtual Groups Group { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<EmployeeSkills> EmployeeSkills { get; set; }
    }
}
