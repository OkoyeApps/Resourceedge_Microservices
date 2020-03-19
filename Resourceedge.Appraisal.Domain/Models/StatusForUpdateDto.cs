using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class StatusForUpdateDto
    {
        public bool? Hod { get; set; }
        public bool? Employee { get; set; }
        public bool? IsAccepted { get; set; }
    }
}
