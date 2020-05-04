using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class InterviewStatus
    {
        public InterviewStatus()
        {
            Interviews = new HashSet<Interviews>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Interviews> Interviews { get; set; }
    }
}
