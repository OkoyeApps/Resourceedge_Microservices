using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Common.Archive
{
        public class Subgroup
        {
            public int SubgroupId { get; set; }
            public int GroupId { get; set; }
            public string Name { get; set; }
            public string Descriptions { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime? ModifiedDate { get; set; }
            public string CreatedBy { get; set; }
            public string ModifiedBy { get; set; }
        }
}
