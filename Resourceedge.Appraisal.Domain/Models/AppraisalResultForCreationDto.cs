using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class AppraisalResultForCreationDto
    {
        public int myId { get; set; }
        public string whoami { get; set; }
        public ObjectId AppraisalConfigId { get; set; }
        public ObjectId AppraisalCycleId { get; set; }
        public ObjectId KeyResultAreaId { get; set; }
        public ICollection<AppraisalKeyOutcome> KeyOutcomeScore { get; set; }
    }
}
