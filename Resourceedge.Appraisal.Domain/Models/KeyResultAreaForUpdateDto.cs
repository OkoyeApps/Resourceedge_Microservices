using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    [BsonIgnoreExtraElements]
    public class KeyResultAreaForUpdateDto
    {
        public KeyResultAreaForUpdateDto()
        {
            this.UpdatedAt = DateTime.UtcNow;
        }
        public NameEmail HeadOfDepartment { get; set; } = new NameEmail { };
        public NameEmail Appraiser { get; set; } = new NameEmail { };
        public ICollection<KeyOutcome> keyOutcomes { get; set; } = new List<KeyOutcome>();
        public BsonDateTime UpdatedAt { get; private set; } = BsonDateTime.Create(DateTime.UtcNow);
    }

    public class KeyOutcomeForUpdate
    {
        public string Question { get; set; }
        public string TimeLimit { get; set; }
    }

    public class KeyResultAreaForUpdateMainDto
    {
        public NameEmail HodDetails { get; set; }
        public NameEmail AppraiserDetails { get; set; }
        public ICollection<KeyOutcome> keyOutcomes { get; set; } = new List<KeyOutcome>();
    }
}
