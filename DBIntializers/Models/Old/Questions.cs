using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Questions
    {
        public Questions()
        {
            AppraisalCriterias = new HashSet<AppraisalCriterias>();
            AppraisalQuestions = new HashSet<AppraisalQuestions>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int LocationId { get; set; }
        public int EpiresultAreaId { get; set; }
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public string EmpQuestion { get; set; }
        public string Description { get; set; }
        public int BusinessUnitId { get; set; }
        public int DepartmentId { get; set; }
        public int CompletionPeriod { get; set; }
        public bool? Approved { get; set; }
        public DateTime? ActualCompletionTime { get; set; }
        public string Createdby { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Isused { get; set; }
        public int? Year { get; set; }
        public string FeedBack { get; set; }
        public bool? ManagerApproval { get; set; }
        public string CustomCompletionTime { get; set; }

        public virtual BusinessUnits BusinessUnit { get; set; }
        public virtual EpiresultAreas EpiresultArea { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<AppraisalCriterias> AppraisalCriterias { get; set; }
        public virtual ICollection<AppraisalQuestions> AppraisalQuestions { get; set; }
    }
}
