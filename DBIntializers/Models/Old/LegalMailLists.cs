using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class LegalMailLists
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public int RequestAgreementId { get; set; }
        public int NotificationType { get; set; }

        public virtual RequestAgreements RequestAgreement { get; set; }
    }
}
