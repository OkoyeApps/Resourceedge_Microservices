using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class PromotionClassifications
    {
        public PromotionClassifications()
        {
            Promotions = new HashSet<Promotions>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? Createdon { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Groups Group { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<Promotions> Promotions { get; set; }
    }
}
