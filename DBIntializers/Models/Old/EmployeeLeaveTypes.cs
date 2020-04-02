using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class EmployeeLeaveTypes
    {
        public EmployeeLeaveTypes()
        {
            LeaveRequests = new HashSet<LeaveRequests>();
        }

        public int Id { get; set; }
        public string Leavetype { get; set; }
        public int? Numberofdays { get; set; }
        public string Leavecode { get; set; }
        public string Description { get; set; }
        public string Leavepreallocated { get; set; }
        public int? Leavepredeductable { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<LeaveRequests> LeaveRequests { get; set; }
    }
}
