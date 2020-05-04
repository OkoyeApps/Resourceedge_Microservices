using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class AgreementTypes
    {
        public AgreementTypes()
        {
            RequestAgreements = new HashSet<RequestAgreements>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TrackingId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Trackings Tracking { get; set; }
        public virtual ICollection<RequestAgreements> RequestAgreements { get; set; }
    }
}
