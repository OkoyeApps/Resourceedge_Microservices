using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class RequestAgreements
    {
        public RequestAgreements()
        {
            LegalMailLists = new HashSet<LegalMailLists>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public int? GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public int? AgreementTypeId { get; set; }
        public int? RequestingStaffId { get; set; }
        public string Product { get; set; }
        public string SignedCompany { get; set; }
        public Guid? TrackingId { get; set; }
        public int? FileId { get; set; }
        public bool? Status { get; set; }
        public DateTime? DateofRequest { get; set; }
        public DateTime? RequestSignDate { get; set; }
        public DateTime? ReturnDateofSignedCopy { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string CompanyName { get; set; }

        public virtual AgreementTypes AgreementType { get; set; }
        public virtual Files File { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Employees RequestingStaff { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual Trackings Tracking { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<LegalMailLists> LegalMailLists { get; set; }
    }
}
