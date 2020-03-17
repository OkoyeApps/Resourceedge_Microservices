using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Entities
{
    
    public class KeyResultAreas
    {
        public ObjectId Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; } = "Strenght";
        [BsonElement("Weight")]
        public decimal Weight { get; set; } = 50;
        [BsonElement("AppraiserUserId")]
        public string AppraiserUserId { get; set; } = "9276363";
        [BsonElement("AppraiserEmail")]
        public string AppraiserEmail { get; set; } = "uhfafjkadnfj";
        [BsonElement("HodUserId")]
        public string HodUserId { get; set; } = "kaeyi92932";
        [BsonElement("HodEmail")]
        public string HodEmail { get; set; } = "khafkjdafjkadf";
    }
}
