using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class DependencyRelations
    {
        public DependencyRelations()
        {
            Dependencies = new HashSet<Dependencies>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Dependencies> Dependencies { get; set; }
    }
}
