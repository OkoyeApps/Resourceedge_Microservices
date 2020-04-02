using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class ConfiguredDefaultManagers
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string LineManager1Id { get; set; }
        public string LineManager2Id { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int LocationId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual AspNetUsers LineManager1 { get; set; }
        public virtual AspNetUsers LineManager2 { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
