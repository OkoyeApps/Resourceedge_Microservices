using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Entities
{
    public class AppraisalConfig
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int TotalCycle { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public List<AppraisalCycle> Cycles{ get; set; }
    }

    public class AppraisalCycle
    {
        public AppraisalCycle()
        {
            Completed = (this.isActive.HasValue && this.isActive.Value) ? false : (this.isActive.HasValue && !this.isActive.Value) ? true : (bool?) null;
        }
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public DateTime StartDate { get; set; } 
        public DateTime StopDate { get; set; }
        public bool? isActive { get; set; }
        public string Name { get; set; }
        public bool? Completed { get; set; }

    }
}
