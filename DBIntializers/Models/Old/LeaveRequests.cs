using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class LeaveRequests
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int LocationId { get; set; }
        public string Reason { get; set; }
        public string ApprovalComment { get; set; }
        public int? LeavetypeId { get; set; }
        public string LeaveName { get; set; }
        public bool? LeaveDay { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? LeaveStatus { get; set; }
        public string RepmangId { get; set; }
        public string HrId { get; set; }
        public double? NoOfDays { get; set; }
        public double? AppliedleavesCount { get; set; }
        public int Availableleave { get; set; }
        public int RequestDaysNo { get; set; }
        public bool? Approval1 { get; set; }
        public bool? Approval2 { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? DateOfResumption { get; set; }
        public bool? CollectAllowance { get; set; }
        public int? UnitId { get; set; }
        public int? DeptId { get; set; }
        public int? ReliefStaffId { get; set; }
        public int Year { get; set; }
        public int? EmployeeLeaveId { get; set; }

        public virtual Departments Dept { get; set; }
        public virtual EmployeeLeaves EmployeeLeave { get; set; }
        public virtual Groups Group { get; set; }
        public virtual AspNetUsers Hr { get; set; }
        public virtual EmployeeLeaveTypes Leavetype { get; set; }
        public virtual Locations Location { get; set; }
        public virtual Employees ReliefStaff { get; set; }
        public virtual AspNetUsers Repmang { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual BusinessUnits Unit { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
