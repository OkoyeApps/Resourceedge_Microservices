using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class SubscribedAppraisals
    {
        public SubscribedAppraisals()
        {
            Recommendations = new HashSet<Recommendations>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Code { get; set; }
        public int? GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public bool? IsActive { get; set; }
        public int? AppraisalInitializationId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int? Year { get; set; }
        public string Reason { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Stop { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? Status { get; set; }

        public virtual AppraisalInitializations AppraisalInitialization { get; set; }
        public virtual Groups Group { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<Recommendations> Recommendations { get; set; }
    }
}
