using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Dependencies
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EmployeeId { get; set; }
        public int GroupId { get; set; }
        public int LocationId { get; set; }
        public string DependentName { get; set; }
        public int DependentRelationId { get; set; }
        public DateTime? DobofDependent { get; set; }
        public int DependentAge { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public int? DependencyRelationId { get; set; }

        public virtual DependencyRelations DependencyRelation { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
    }
}
