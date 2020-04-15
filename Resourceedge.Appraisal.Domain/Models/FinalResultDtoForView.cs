using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class FinalResultDtoForView
    {
        public int EmployeeId { get; set; }
        public double EmployeeResult { get; set; }
        public double? FinalResult { get; set; }
    }
}
