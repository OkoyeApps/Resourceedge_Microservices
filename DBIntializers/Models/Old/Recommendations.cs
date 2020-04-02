using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Recommendations
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int AppraisalInitializationId { get; set; }
        public int SubscriptionId { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public string UserId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string MajorStrength { get; set; }
        public string AreaToImprovement { get; set; }
        public string RecommendTraining { get; set; }

        public virtual AppraisalInitializations AppraisalInitialization { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual SubscribedAppraisals Subscription { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
