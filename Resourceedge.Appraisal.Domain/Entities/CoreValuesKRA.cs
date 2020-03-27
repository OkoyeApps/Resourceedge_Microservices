using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Entities
{
    public class CoreValuesKRA
    {
        [BsonElement]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public bool? Approved { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public bool IsActive { get; set; }
        public ICollection<KeyOutcome> keyOutcomes { get; set; } = new List<KeyOutcome>();
    }
}
