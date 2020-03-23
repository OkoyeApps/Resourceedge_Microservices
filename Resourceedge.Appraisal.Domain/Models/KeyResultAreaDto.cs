using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class KeyResultAreaDtoForCreation
    {
        public string Name { get; set; }
        public string myId { get; set; }
        public decimal Weight { get; set; }
        public NameEmail HeadOfDepartment { get; set; }
        public NameEmail Appraiser { get; set; }
        public bool? Approved { get; set; }
        public ICollection<KeyOutcome> keyOutcomes { get; set; } = new List<KeyOutcome>();
        public ApprovalStatus Status { get; set; }

    }

    public class KeyResultAreaForViewDto
    {
        private string currentPosition = "appraiser";
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public decimal Weight { get; set; }
        public NameEmail HeadOfDepartment { get; set; }
        public NameEmail Appraiser { get; set; }
        public bool? Approved { get; set; }
        public string whoami { get; set; }
        public ICollection<KeyOutcome> keyOutcomes { get; set; } = new List<KeyOutcome>();
        public ApprovalStatus Status { get; set; }

    }
}
