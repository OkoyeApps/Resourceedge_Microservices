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
        public ICollection<AppraisalKeyOutcomeDto> KeyOutcomeScore { get; set; }
    }

    public class AppraisalResultForCreationDtoString
    {
        public int myId { get; set; }
        public string AppraisalConfigId { get; set; }
        public string AppraisalCycleId { get; set; }
        public string KeyResultAreaId { get; set; }
        public ICollection<AppraisalKeyOutcomeDtoString> KeyOutcomeScore { get; set; }

    }

    public class AppraisalKeyOutcomeDtoString
    {
        public string KeyOutcomeId { get; set; }
        public int EmployeeScore { get; set; }
        public FeedBack AppraiseeFeedBack { get; set; }
    }

    public class AppraisalKeyOutcomeDto
    {
        public ObjectId KeyOutcomeId { get; set; }
        public int EmployeeScore { get; set; }
        public FeedBack AppraiseeFeedBack { get; set; }

    }

}
