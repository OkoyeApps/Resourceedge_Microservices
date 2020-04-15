using MongoDB.Bson.Serialization.Attributes;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    [BsonIgnoreExtraElements]
    public class AppraisalForApprovalDto 
    {
        public BasicEmployee EmployeeDetail { get; set; } = new BasicEmployee();
        public IEnumerable<AppraisalResult> Kra_Details { get; set; } = new List<AppraisalResult>();
    }

    [BsonIgnoreExtraElements]
    public class AppraisalForApprovalViewDto
    {
        public BasicEmployee EmployeeDetail { get; set; } = new BasicEmployee();
        public IEnumerable<AppraisalResultForViewDto> Kra_Details { get; set; } = new List<AppraisalResultForViewDto>();
    }
}
