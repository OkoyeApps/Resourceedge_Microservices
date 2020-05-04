using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class CooperateCards
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EmployeeId { get; set; }
        public int GroupId { get; set; }
        public int LocationId { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string IssuedBy { get; set; }
        public string Code { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
    }
}
