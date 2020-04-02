using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class AssetCategories
    {
        public AssetCategories()
        {
            Assets = new HashSet<Assets>();
            RequestAssets = new HashSet<RequestAssets>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public int SubGroupId { get; set; }

        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<Assets> Assets { get; set; }
        public virtual ICollection<RequestAssets> RequestAssets { get; set; }
    }
}
