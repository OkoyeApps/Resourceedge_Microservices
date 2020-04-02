using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class EducationLevels
    {
        public EducationLevels()
        {
            Educations = new HashSet<Educations>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Educations> Educations { get; set; }
    }
}
