using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Promotions
    {
        public Promotions()
        {
            EmployeePromotions = new HashSet<EmployeePromotions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PromotionNo { get; set; }
        public int? EligibleLevel { get; set; }
        public int? MinimumYears { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public int GroupId { get; set; }
        public int? SubgroupId { get; set; }
        public int? PromotionClasssificationId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual PromotionClassifications PromotionClasssification { get; set; }
        public virtual SubGroups Subgroup { get; set; }
        public virtual ICollection<EmployeePromotions> EmployeePromotions { get; set; }
    }
}
