using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class PersonalSkills
    {
        public PersonalSkills()
        {
            EmployeeSkills = new HashSet<EmployeeSkills>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public int EmployeeId { get; set; }
        public int GroupId { get; set; }
        public int BusinessUnitId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int ExperienceYear { get; set; }
        public DateTime? YearAcquired { get; set; }
        public DateTime? LastUsedDate { get; set; }
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
        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<EmployeeSkills> EmployeeSkills { get; set; }
    }
}
