using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class AppraisalConfigForCreationDto
    {
        public string Name { get; set; }
        public int Total { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public List<AppraisalCycleClass> Cycles { get; set; }
    }

    public class AppraisalCycleClass
    {
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
    }
}
