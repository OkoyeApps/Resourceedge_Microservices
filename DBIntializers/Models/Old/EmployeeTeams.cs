using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class EmployeeTeams
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public int? LocationId { get; set; }
        public int TeamId { get; set; }
        public int? DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public string UserId { get; set; }
        public bool? IsTeamHead { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsFormerTeam { get; set; }
        public DateTime? DateLeft { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Teams Team { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
