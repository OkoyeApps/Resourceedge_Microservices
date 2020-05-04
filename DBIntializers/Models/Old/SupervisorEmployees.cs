using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class SupervisorEmployees
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int LocationId { get; set; }
        public int SupervisorId { get; set; }
        public string SuperviseeId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual AspNetUsers Supervisee { get; set; }
        public virtual LineManager2 Supervisor { get; set; }
    }
}
