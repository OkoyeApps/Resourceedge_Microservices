using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Jobtitles
    {
        public Jobtitles()
        {
            Employees = new HashSet<Employees>();
            JobHistories = new HashSet<JobHistories>();
            Positions = new HashSet<Positions>();
            Requisitions = new HashSet<Requisitions>();
        }

        public int Id { get; set; }
        public int SubGroupId { get; set; }
        public int GroupId { get; set; }
        public int? LocationId { get; set; }
        public string Jobtitlecode { get; set; }
        public string Jobtitlename { get; set; }
        public string Jobdescription { get; set; }
        public double? Minexperiencerequired { get; set; }
        public string Jobpaygradecode { get; set; }
        public string Jobpayfrequency { get; set; }
        public string Comments { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool? Isactive { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<JobHistories> JobHistories { get; set; }
        public virtual ICollection<Positions> Positions { get; set; }
        public virtual ICollection<Requisitions> Requisitions { get; set; }
    }
}
