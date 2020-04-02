using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class CoreValueKRAForViewDto 
    {
        private string currentPosition = "appraiser";
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public decimal Weight { get; set; }
        public bool? Approved { get; set; }
        public string whoami { get; set; }
        public ICollection<KeyOutcome> keyoutcomes { get; set; } = new List<KeyOutcome>();
    }
}
