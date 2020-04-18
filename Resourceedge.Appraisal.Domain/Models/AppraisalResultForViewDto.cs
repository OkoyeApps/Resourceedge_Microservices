using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class AppraisalResultForViewDto
    {
        public ObjectId Id { get; set; }
        public ObjectId AppraisalConfigId { get; set; }
        public ObjectId AppraisalCycleId { get; set; }
        public KeyResultAreaForViewDto KeyResultArea { get; set; }
        public ICollection<AppraisalKeyOutcome> KeyOutcomeScore { get; set; }
        public FeedBack AppraiseeFeedBack { get; set; }
        public bool? IsAccepted { get; set; }
        public bool? IsCompleted { get; set; }
        public string CurrentSupervisor { get; set; }
        public string NextAppraisee { get; set; }
        public AcceptanceStatus EmployeeAccept { get; set; }
        public AcceptanceStatus HodAccept { get; set; }
    }
}
