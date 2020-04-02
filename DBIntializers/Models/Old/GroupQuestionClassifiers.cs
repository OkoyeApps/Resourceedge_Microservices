using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class GroupQuestionClassifiers
    {
        public GroupQuestionClassifiers()
        {
            AppraisalQuestions = new HashSet<AppraisalQuestions>();
            GeneralQuestions = new HashSet<GeneralQuestions>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public int Year { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public decimal? CalculationPercentage { get; set; }

        public virtual Groups Group { get; set; }
        public virtual ICollection<AppraisalQuestions> AppraisalQuestions { get; set; }
        public virtual ICollection<GeneralQuestions> GeneralQuestions { get; set; }
    }
}
