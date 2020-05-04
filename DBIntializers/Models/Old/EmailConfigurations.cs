using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class EmailConfigurations
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int LocationId { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public int MailType { get; set; }
        public int MailAction { get; set; }
        public Guid? TrackingId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual Trackings Tracking { get; set; }
    }
}
