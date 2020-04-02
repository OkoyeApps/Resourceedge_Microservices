using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Positions
    {
        public Positions()
        {
            Employees = new HashSet<Employees>();
            JobHistories = new HashSet<JobHistories>();
            Requisitions = new HashSet<Requisitions>();
        }

        public int Id { get; set; }
        public string Positionname { get; set; }
        public int JobtitleId { get; set; }
        public string Description { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool? Isactive { get; set; }

        public virtual Jobtitles Jobtitle { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<JobHistories> JobHistories { get; set; }
        public virtual ICollection<Requisitions> Requisitions { get; set; }
    }
}
