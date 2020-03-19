using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Entities
{
    public class AppraisalResult
    {
        public ObjectId Id { get; set; }
        public int myId { get; set; }
        public ObjectId AppraisalConfigId { get; set; }
        public ObjectId AppraisalCycleId { get; set; }
        public ObjectId KeyResultAreaId { get; set; }
        public ICollection<AppraisalKeyOutcome> KeyOutcomeScore { get; set; }
    }

    public class AppraisalKeyOutcome
    {
        public ObjectId KeyOutcomeId { get; set; }
        public int EmployeeScore { get; set; }
        public string HodScore { get; set; }
    }
}
