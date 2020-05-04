using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Prefixes
    {
        public int Id { get; set; }
        public string PrefixName { get; set; }
        public string Description { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool? Isactive { get; set; }
    }
}
