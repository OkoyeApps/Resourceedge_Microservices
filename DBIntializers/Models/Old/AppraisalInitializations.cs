using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class AppraisalInitializations
    {
        public AppraisalInitializations()
        {
            AppraisalConfigurations = new HashSet<AppraisalConfigurations>();
            AppraisalQuestions = new HashSet<AppraisalQuestions>();
            AppraisalResults = new HashSet<AppraisalResults>();
            Recommendations = new HashSet<Recommendations>();
            SubscribedAppraisals = new HashSet<SubscribedAppraisals>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public int? AppraisalModeId { get; set; }
        public int? AppraisalPeriodId { get; set; }
        public int? AppraisalRatingId { get; set; }
        public int? AppraisalStatusId { get; set; }
        public string InitilizationCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Enable { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public int? Year { get; set; }
        public string Reason { get; set; }

        public virtual Groups Group { get; set; }
        public virtual ICollection<AppraisalConfigurations> AppraisalConfigurations { get; set; }
        public virtual ICollection<AppraisalQuestions> AppraisalQuestions { get; set; }
        public virtual ICollection<AppraisalResults> AppraisalResults { get; set; }
        public virtual ICollection<Recommendations> Recommendations { get; set; }
        public virtual ICollection<SubscribedAppraisals> SubscribedAppraisals { get; set; }
    }
}
