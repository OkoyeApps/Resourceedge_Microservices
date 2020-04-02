using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Trackings
    {
        public Trackings()
        {
            AgreementTypes = new HashSet<AgreementTypes>();
            EmailConfigurations = new HashSet<EmailConfigurations>();
            RequestAgreements = new HashSet<RequestAgreements>();
        }

        public Guid Id { get; set; }
        public string CreatedId { get; set; }
        public string ModifiedId { get; set; }
        public string DeletedId { get; set; }
        public int? GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public int? EmployeeId { get; set; }
        public string UserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual AspNetUsers Created { get; set; }
        public virtual AspNetUsers Deleted { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Groups Group { get; set; }
        public virtual AspNetUsers Modified { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<AgreementTypes> AgreementTypes { get; set; }
        public virtual ICollection<EmailConfigurations> EmailConfigurations { get; set; }
        public virtual ICollection<RequestAgreements> RequestAgreements { get; set; }
    }
}
