using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class CoreValueForUpdateDto 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Approved { get; set; }
        public bool IsActive { get; set; }
    }
}
