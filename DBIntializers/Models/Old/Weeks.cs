using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Weeks
    {
        public int Id { get; set; }
        public string WeekId { get; set; }
        public string WeekName { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Isactive { get; set; }
    }
}
