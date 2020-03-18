using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class AppraisalConfigCreationDto
    {
        public string Name { get; set; }
        public int Cycles { get; set; } = DateTime.Now.Year;
        public List<AppraisalCycle> Periods { get; set; }
    }
}
