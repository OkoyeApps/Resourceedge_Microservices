using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class EmpHolidays
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? HolidayGroupId { get; set; }
        public int? Createdby { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool? Isactive { get; set; }
    }
}
