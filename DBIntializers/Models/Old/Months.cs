using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Months
    {
        public int Id { get; set; }
        public string MonthId { get; set; }
        public string MonthName { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Isactive { get; set; }
    }
}
