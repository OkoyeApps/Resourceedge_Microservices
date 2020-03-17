using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Entities
{
    class KeyResultAreas
    {
        public ObjectId Id { get; set; }
        [BsonElement("KeyResultAreaId")]
        public int KeyResultAreaId { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Weight")]
        public decimal Weight { get; set; }
        [BsonElement("AppraiserUserId")]
        public string AppraiserUserId { get; set; }
        [BsonElement("AppraiserEmail")]
        public string AppraiserEmail { get; set; }
        [BsonElement("HodUserId")]
        public string HodUserId { get; set; }
        [BsonElement("HodEmail")]
        public string HodEmail { get; set; }
    }
}
