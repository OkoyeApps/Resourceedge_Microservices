using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Educations
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EmployeeId { get; set; }
        public int GroupId { get; set; }
        public int LocationId { get; set; }
        public int EducationlevelId { get; set; }
        public string InstitutionName { get; set; }
        public string Course { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual EducationLevels Educationlevel { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
    }
}
