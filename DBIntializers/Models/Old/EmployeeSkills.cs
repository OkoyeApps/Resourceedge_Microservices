using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class EmployeeSkills
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? PersonalSkillId { get; set; }
        public int? DepartmentSkillId { get; set; }
        public DateTime? YearAcquired { get; set; }

        public virtual DepartmentalSkills DepartmentSkill { get; set; }
        public virtual PersonalSkills PersonalSkill { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
