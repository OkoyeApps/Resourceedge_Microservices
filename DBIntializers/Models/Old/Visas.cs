using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Visas
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EmployeeId { get; set; }
        public int GroupId { get; set; }
        public int LocationId { get; set; }
        public string PassportNumber { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string VisaTypeCode { get; set; }
        public int VisaNumber { get; set; }
        public DateTime? VisaIssuedDate { get; set; }
        public DateTime? VisaExpiryDate { get; set; }
        public string OneToNineStatus { get; set; }
        public DateTime OneToNineReviewDate { get; set; }
        public string IssuingAuthority { get; set; }
        public string OneToNightyFourStatus { get; set; }
        public DateTime? OneToNightyFourExpiryDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
    }
}
