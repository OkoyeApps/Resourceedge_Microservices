using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class LeaveManagementSummaries
    {
        public int Id { get; set; }
        public int? LeavemgmtId { get; set; }
        public int? CalStartmonth { get; set; }
        public string CalStartmonthname { get; set; }
        public int? WeekendStartday { get; set; }
        public string WeekendStartdayname { get; set; }
        public int? WeekendEndday { get; set; }
        public string WeekendEnddayname { get; set; }
        public int? BusinessunitId { get; set; }
        public string BusinessunitName { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? HoursDay { get; set; }
        public string IsSatholiday { get; set; }
        public string IsHalfday { get; set; }
        public string IsLeavetransfer { get; set; }
        public string IsSkipholidays { get; set; }
        public string Descriptions { get; set; }
        public int? Createdby { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool? Isactive { get; set; }
    }
}
