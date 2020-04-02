using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class LocationHeadUnits
    {
        public int Id { get; set; }
        public int SubGroupId { get; set; }
        public int LocationId { get; set; }
        public int LineManagerId { get; set; }
        public int BusinessUnitId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? Active { get; set; }

        public virtual BusinessUnits BusinessUnit { get; set; }
        public virtual LineManager1 LineManager { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
    }
}
