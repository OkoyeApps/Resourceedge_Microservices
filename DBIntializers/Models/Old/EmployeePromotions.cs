using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class EmployeePromotions
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? EmployeeId { get; set; }
        public int? PromotionId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? DepartmentId { get; set; }
        public int? BusinessUnitId { get; set; }
        public int? SubGroupId { get; set; }
        public int GroupId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual BusinessUnits BusinessUnit { get; set; }
        public virtual Departments Department { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Promotions Promotion { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
