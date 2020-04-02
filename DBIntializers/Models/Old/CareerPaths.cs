using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class CareerPaths
    {
        public int Id { get; set; }
        public int CarreerId { get; set; }
        public int LevelId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int? CarrierNameId { get; set; }

        public virtual Careers CarrierName { get; set; }
        public virtual Levels Level { get; set; }
    }
}
