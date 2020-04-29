using MongoDB.Bson.Serialization.Attributes;
using Resourceedge.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    [BsonIgnoreExtraElements]
    public class FinalResultDtoForView
    {
        public int EmployeeId { get; set; }
        public double EmployeeResult { get; set; }
        public double AppraiseeResult { get; set; }
        public double? FinalResult { get; set; }

    }
    [BsonIgnoreExtraElements]

    public class FinalAppraisalResultForViewDto
    {
        public BasicEmployee EmployeeDetail { get; set; } = new BasicEmployee();
        public FinalResultDtoForView Result { get; set; } = new FinalResultDtoForView();
    }

    public class OrgaizationandCount
    {
        public string Group { get; set; }
        public int Count { get; set; }
    }
}
