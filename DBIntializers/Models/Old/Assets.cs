using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Assets
    {
        public Assets()
        {
            RequestAssets = new HashSet<RequestAssets>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public bool IsInUse { get; set; }
        public string ImageUrl { get; set; }
        public int AssetCategoryId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int SubGroupId { get; set; }

        public virtual AssetCategories AssetCategory { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<RequestAssets> RequestAssets { get; set; }
    }
}
