using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class MedicalClaimTypes
    {
        public MedicalClaimTypes()
        {
            MedicalClaims = new HashSet<MedicalClaims>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<MedicalClaims> MedicalClaims { get; set; }
    }
}
