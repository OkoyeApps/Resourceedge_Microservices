using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Ratings
    {
        public int Id { get; set; }
        public int? RatingValue { get; set; }
        public string RatingText { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Isactive { get; set; }
    }
}
