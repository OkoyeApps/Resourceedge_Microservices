using MongoDB.Bson.Serialization.Attributes;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    [BsonIgnoreExtraElements]
    public class KeyResultAreaForUpdateDto
    {
        public NameEmail HeadOfDepartment { get; set; } = new NameEmail { };
        public NameEmail Appraiser { get; set; } = new NameEmail { };
        public ICollection<KeyOutcome> keyOutcomes { get; set; } = new List<KeyOutcome>();
    }

    public class KeyResultAreaForUpdateMainDto
    {
        public NameEmail HodDetails { get; set; }
        public NameEmail AppraiserDetails { get; set; }
        public ICollection<KeyOutcome> keyOutcomes { get; set; } = new List<KeyOutcome>();
    }
}
