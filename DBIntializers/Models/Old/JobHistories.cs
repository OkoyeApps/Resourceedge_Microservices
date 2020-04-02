using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class JobHistories
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EmployeeId { get; set; }
        public int GroupId { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
        public int JobId { get; set; }
        public int PositionId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public double AmountRecieved { get; set; }
        public double AmountPaid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Jobtitles Job { get; set; }
        public virtual Locations Location { get; set; }
        public virtual Positions Position { get; set; }
    }
}
