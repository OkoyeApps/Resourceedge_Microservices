using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Careers
    {
        public Careers()
        {
            CareerPaths = new HashSet<CareerPaths>();
        }

        public int Id { get; set; }
        public string CareerName { get; set; }
        public string ShortCode { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<CareerPaths> CareerPaths { get; set; }
    }
}
