using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class JobParameter
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Job Job { get; set; }
    }
}
