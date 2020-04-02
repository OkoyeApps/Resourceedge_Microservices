using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Birthdays
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
        public int LocationId { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int SubGroupId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
    }
}
