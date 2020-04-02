using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Requisitions
    {
        public Requisitions()
        {
            Candidates = new HashSet<Candidates>();
            Interviews = new HashSet<Interviews>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int LocationId { get; set; }
        public string RequisitionCode { get; set; }
        public DateTime? OnboardDate { get; set; }
        public int? PositionId { get; set; }
        public string ReportingId { get; set; }
        public int? BusinessUnitId { get; set; }
        public int? DepartmentId { get; set; }
        public int? JobTitleId { get; set; }
        public string ReqNoPositions { get; set; }
        public string SelectedMembers { get; set; }
        public string FilledPositions { get; set; }
        public string JobDescription { get; set; }
        public string ReqSkills { get; set; }
        public string ReqQualification { get; set; }
        public string ReqExpYears { get; set; }
        public string EmpType { get; set; }
        public string ReqPriority { get; set; }
        public string AdditionalInfo { get; set; }
        public string ReqStatus { get; set; }
        public string Approver1 { get; set; }
        public string Approver2 { get; set; }
        public string Approver3 { get; set; }
        public bool? AppStatus1 { get; set; }
        public bool? AppStatus2 { get; set; }
        public bool? AppStatus3 { get; set; }
        public string Recruiters { get; set; }
        public string ClientId { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Isactive { get; set; }

        public virtual BusinessUnits BusinessUnit { get; set; }
        public virtual Departments Department { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Jobtitles JobTitle { get; set; }
        public virtual Locations Location { get; set; }
        public virtual Positions Position { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<Candidates> Candidates { get; set; }
        public virtual ICollection<Interviews> Interviews { get; set; }
    }
}
