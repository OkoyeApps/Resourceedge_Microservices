using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class RequestAssets
    {
        public int Id { get; set; }
        public int AssetCategoryId { get; set; }
        public int AssetId { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int LocationId { get; set; }
        public int Amount { get; set; }
        public DateTime? DueTime { get; set; }
        public string RequestedBy { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByFullName { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsResolved { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Assets Asset { get; set; }
        public virtual AssetCategories AssetCategory { get; set; }
    }
}
