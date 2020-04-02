using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Candidates
    {
        public Candidates()
        {
            CandidateInterviews = new HashSet<CandidateInterviews>();
            CandidateWorkDetails = new HashSet<CandidateWorkDetails>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int RequisitionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileImage { get; set; }
        public string Resume { get; set; }
        public string Qualification { get; set; }
        public string EducationSummary { get; set; }
        public int Experience { get; set; }
        public string Skills { get; set; }
        public bool? Status { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public int SubGroupId { get; set; }

        public virtual Requisitions Requisition { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<CandidateInterviews> CandidateInterviews { get; set; }
        public virtual ICollection<CandidateWorkDetails> CandidateWorkDetails { get; set; }
    }
}
