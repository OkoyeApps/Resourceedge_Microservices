using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class TrainingAndCertifications
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EmployeeId { get; set; }
        public int GroupId { get; set; }
        public int LocationId { get; set; }
        public string CreatedBy { get; set; }
        public string CourseName { get; set; }
        public string CourseLevel { get; set; }
        public string CouserOfferedBy { get; set; }
        public string Description { get; set; }
        public string CertificateName { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
    }
}
