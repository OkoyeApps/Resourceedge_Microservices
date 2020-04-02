using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class AppraisalQuestions
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int LocationId { get; set; }
        public int EmployeeId { get; set; }
        public int? EpiResultAreaId { get; set; }
        public int? QuestionId { get; set; }
        public int? GeneralQuestionId { get; set; }
        public int? BusinessUnitId { get; set; }
        public int? DepartmentQuestionId { get; set; }
        public decimal Answer { get; set; }
        public string LineManager1 { get; set; }
        public string LineManager2 { get; set; }
        public string LineManager3 { get; set; }
        public bool? L1status { get; set; }
        public bool? L2status { get; set; }
        public bool? L3status { get; set; }
        public int? EditCount { get; set; }
        public bool? IsSubmitted { get; set; }
        public bool? IsAccepted { get; set; }
        public DateTime? ActualCompletionTime { get; set; }
        public decimal? AppraiseeRating { get; set; }
        public bool? IsEdited { get; set; }
        public int? AppraisalInitializationId { get; set; }
        public bool? Completed { get; set; }
        public int? CurrentLineManagerForApproval { get; set; }
        public string AppraiseeComment { get; set; }
        public string AppraisarComment { get; set; }
        public string GeneralComment { get; set; }
        public int CompletionPeriod { get; set; }
        public string CustomCompletionTime { get; set; }
        public int? ClassificationId { get; set; }

        public virtual AppraisalInitializations AppraisalInitialization { get; set; }
        public virtual GroupQuestionClassifiers Classification { get; set; }
        public virtual GeneralQuestions DepartmentQuestion { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual EpiresultAreas EpiResultArea { get; set; }
        public virtual GeneralQuestions GeneralQuestion { get; set; }
        public virtual Questions Question { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
