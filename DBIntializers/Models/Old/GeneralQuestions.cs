using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class GeneralQuestions
    {
        public GeneralQuestions()
        {
            AppraisalQuestionsDepartmentQuestion = new HashSet<AppraisalQuestions>();
            AppraisalQuestionsGeneralQuestion = new HashSet<AppraisalQuestions>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public int? LocationId { get; set; }
        public int? BusinessUnitId { get; set; }
        public int? DepartmentId { get; set; }
        public int? EpiresultAreaId { get; set; }
        public string Question { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public int? Year { get; set; }
        public int? ClassificationId { get; set; }

        public virtual BusinessUnits BusinessUnit { get; set; }
        public virtual GroupQuestionClassifiers Classification { get; set; }
        public virtual Departments Department { get; set; }
        public virtual EpiresultAreas EpiresultArea { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<AppraisalQuestions> AppraisalQuestionsDepartmentQuestion { get; set; }
        public virtual ICollection<AppraisalQuestions> AppraisalQuestionsGeneralQuestion { get; set; }
    }
}
