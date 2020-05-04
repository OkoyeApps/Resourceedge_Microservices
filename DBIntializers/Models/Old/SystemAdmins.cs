using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class SystemAdmins
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
        public int? LocationId { get; set; }
        public int? SubGroupId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
    }
}
