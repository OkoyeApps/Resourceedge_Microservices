using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class KeyOutcomeForUpdateDto
    {
        public KeyOutcomeDto keyOutcomes { get; set; } = new KeyOutcomeDto();
    }

    public class KeyOutcomeDto
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string Question { get; set; }
        public string TimeLimit { get; set; }
    }
}
