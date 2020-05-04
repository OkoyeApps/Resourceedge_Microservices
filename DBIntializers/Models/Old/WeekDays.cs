using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class WeekDays
    {
        public int Id { get; set; }
        public string DayName { get; set; }
        public string DayShortCode { get; set; }
        public string DayLongCode { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Isactive { get; set; }
    }
}
