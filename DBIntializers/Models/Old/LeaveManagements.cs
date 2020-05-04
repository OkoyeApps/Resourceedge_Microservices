using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class LeaveManagements
    {
        public int Id { get; set; }
        public string CalStartMonth { get; set; }
        public string WeekendStartDay { get; set; }
        public string WeekendEndDay { get; set; }
        public int? BusinessunitId { get; set; }
        public string DepartmentId { get; set; }
        public string HrId { get; set; }
        public string HoursDay { get; set; }
        public string IsSatHoliday { get; set; }
        public int IsHalfday { get; set; }
        public int IsLeaveTransfer { get; set; }
        public int IsSkipHolidays { get; set; }
        public string Descriptions { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Isactive { get; set; }

        public virtual BusinessUnits Businessunit { get; set; }
        public virtual ReportManagers Hr { get; set; }
    }
}
