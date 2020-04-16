using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class AppraisalConfigForCreationDto
    {
        public string Name { get; set; }
        [Required]
        public int Total { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public List<AppraisalCycleClass> Cycles { get; set; }
    }

    public class AppraisalCycleClass
    {
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime Stop { get; set; }
        public bool? isActive { get; set; }
    }

    public class AppraisalCycleForAppraisal
    {
        public ObjectId ConfigId { get; set; }
        public AppraisalCycle Cycle { get; set; }
    }

}
