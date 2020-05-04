using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class EmployeeLeaveByLevels
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int LevelId { get; set; }
        public double? NumberOfDays { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? HrToUse { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Levels Level { get; set; }
    }
}
