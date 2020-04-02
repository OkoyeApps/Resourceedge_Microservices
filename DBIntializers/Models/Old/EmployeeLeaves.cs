using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class EmployeeLeaves
    {
        public EmployeeLeaves()
        {
            LeaveRequests = new HashSet<LeaveRequests>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public double? EmpLeaveLimit { get; set; }
        public double? UsedLeaves { get; set; }
        public int AllotedYear { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Isactive { get; set; }
        public string HrId { get; set; }
        public bool? IsLeaveTransferSet { get; set; }
        public int AddedDays { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int LocationId { get; set; }
        public int? TotalNumberOfLeaveTaken { get; set; }

        public virtual Groups Group { get; set; }
        public virtual AspNetUsers Hr { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<LeaveRequests> LeaveRequests { get; set; }
    }
}
