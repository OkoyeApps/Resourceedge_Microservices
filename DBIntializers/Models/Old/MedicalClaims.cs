using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class MedicalClaims
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EmployeeId { get; set; }
        public int GroupId { get; set; }
        public int LocationId { get; set; }
        public int MedicalClaimId { get; set; }
        public DateTime? DateOfClaim { get; set; }
        public int Severity { get; set; }
        public string Description { get; set; }
        public string MedicalInsurer { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual MedicalClaimTypes MedicalClaim { get; set; }
    }
}
