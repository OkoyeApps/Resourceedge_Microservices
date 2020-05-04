using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Parameters
    {
        public int Id { get; set; }
        public string ParameterName { get; set; }
        public string Descriptions { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool? Isactive { get; set; }
    }
}
