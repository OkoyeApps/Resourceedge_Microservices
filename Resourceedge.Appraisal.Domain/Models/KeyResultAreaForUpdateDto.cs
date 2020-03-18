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
        public NameEmail HeadOfDepartment { get; set; }
        public NameEmail Appraiser { get; set; }
        public bool? Approved { get; set; }
        public ICollection<KeyOutcome> keyOutcomes { get; set; } = new List<KeyOutcome>();

    }
}
