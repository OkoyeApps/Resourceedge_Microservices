using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class AppraisalResults
    {
        public int Id { get; set; }
        public int? AppraisalInitializationId { get; set; }
        public string UserId { get; set; }
        public decimal? Score { get; set; }
        public int? GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public string FullName { get; set; }
        public int? BusinessUnitId { get; set; }
        public int? DepartmentId { get; set; }
        public decimal? AppraiseeTotal { get; set; }
        public decimal? AppraiserTotal { get; set; }
        public decimal? AppraiseeAverage { get; set; }
        public decimal? AppraiserAverage { get; set; }
        public string LineManager1Id { get; set; }
        public string LineManager2Id { get; set; }
        public string LineManager3Id { get; set; }

        public virtual AppraisalInitializations AppraisalInitialization { get; set; }
        public virtual BusinessUnits BusinessUnit { get; set; }
        public virtual Departments Department { get; set; }
        public virtual Groups Group { get; set; }
        public virtual AspNetUsers LineManager1 { get; set; }
        public virtual AspNetUsers LineManager2 { get; set; }
        public virtual AspNetUsers LineManager3 { get; set; }
        public virtual SubGroups SubGroup { get; set; }
    }
}
