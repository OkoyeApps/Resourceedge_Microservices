using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class CandidateWorkDetails
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyDesignation { get; set; }
        public DateTime? CompanyFrom { get; set; }
        public DateTime? CompanyTo { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Candidates Candidate { get; set; }
    }
}
