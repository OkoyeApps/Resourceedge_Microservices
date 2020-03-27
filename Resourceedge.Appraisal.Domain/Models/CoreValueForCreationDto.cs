using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class CoreValueForCreationDto
    {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public bool? Approved { get; set; }
        public ICollection<KeyOutcome> keyOutcomes { get; set; } = new List<KeyOutcome>();
    }
}
