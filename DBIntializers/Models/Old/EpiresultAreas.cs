using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class EpiresultAreas
    {
        public EpiresultAreas()
        {
            AppraisalQuestions = new HashSet<AppraisalQuestions>();
            GeneralQuestions = new HashSet<GeneralQuestions>();
            Questions = new HashSet<Questions>();
        }

        public int Id { get; set; }
        public int SubGroupId { get; set; }
        public int? LocationId { get; set; }
        public string Name { get; set; }
        public int? EmployeeId { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsSubGroupId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? GroupId { get; set; }
        public int? Year { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<AppraisalQuestions> AppraisalQuestions { get; set; }
        public virtual ICollection<GeneralQuestions> GeneralQuestions { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
