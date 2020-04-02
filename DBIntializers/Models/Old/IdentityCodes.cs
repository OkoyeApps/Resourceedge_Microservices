using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class IdentityCodes
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string BackgroundagencyCode { get; set; }
        public string VendorsCode { get; set; }
        public string StaffingCode { get; set; }
        public string UsersCode { get; set; }
        public string RequisitionCode { get; set; }
        public int SubGroupId { get; set; }
        public int GroupId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Createddate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? Modifieddate { get; set; }

        public virtual Groups Group { get; set; }
        public virtual SubGroups SubGroup { get; set; }
    }
}
