using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Entities
{

    public class KeyResultArea
    {
        public ObjectId Id { get; set; }
        public string UserId { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public NameEmail HodDetails { get; set; } = new NameEmail();
        public NameEmail AppraiserDetails { get; set; } = new NameEmail();
        public bool? Approved { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public bool IsActive { get; set; }
        public ICollection<KeyOutcome> keyOutcomes { get; set; } = new List<KeyOutcome>();
        public ApprovalStatus Status { get; set; } = new ApprovalStatus();
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime UpdatedAt { get; set; }


    }

    public class NameEmail
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class KeyOutcome
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string Question { get; set; }
        public string TimeLimit { get; set; }
        public ApprovalStatus Status { get; set; } = new ApprovalStatus();
    }
    public class ApprovalStatus
    {
        public bool? Hod { get; set; } = null;
        public bool? Employee { get; set; } = null;
        public bool? IsAccepted { get; set; } = null;
    }
}
