using Resourceedge.Common.Archive;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
  public   class EpaToApproveDto : OldEmployeeDto
    {
        public bool? HasApproved { get; set; }
    }
}
