using MongoDB.Bson;
using System.Collections.Generic;

namespace Resourceedge.Appraisal.Domain.Entities
{
    public class AppraisalResult
    {
        public ObjectId Id { get; set; }
        public int myId { get; set; }
        public ObjectId AppraisalConfigId { get; set; }
        public ObjectId AppraisalCycleId { get; set; }
        public KeyResultArea KeyResultArea { get; set; }
        public ICollection<AppraisalKeyOutcome> KeyOutcomeScore { get; set; }
        public FeedBack AppraiseeFeedBack { get; set; }
        public bool? IsAccepted { get; set; }
        public bool? IsCompleted { get; set; }
        public string CurrentSupervisor { get; set; }
        public AcceptanceStatus EmployeeAccept { get; set; }
        public AcceptanceStatus HodAccept { get; set; }
        public AppraisalCalculationByKRA EmployeeCalculation { get; set; }
        public AppraisalCalculationByKRA FinalCalculation { get; set; }
    }

    public class AppraisalKeyOutcome
    {
        public ObjectId KeyOutcomeId { get; set; }
        public int? EmployeeScore { get; set; }
        public int? AppraisalScore { get; set; }
        public int? HodScore { get; set; }
    }

    public class FeedBack
    {
        public string Comment { get; set; }
        public string Recommendation { get; set; }
    }

    public class AcceptanceStatus
    {
        public bool? IsAccepted { get; set; }
        public string Reason { get; set; }
    }

    public class AppraisalCalculationByKRA
    {
        public double ScoreTotal { get; set; }
        public double Average { get; set; }
        public double WeightContribution { get; set; }
    }
}
