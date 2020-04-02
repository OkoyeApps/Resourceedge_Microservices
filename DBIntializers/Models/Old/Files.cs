using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Files
    {
        public Files()
        {
            RequestAgreements = new HashSet<RequestAgreements>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string FileName { get; set; }
        public int FileType { get; set; }
        public string FilePath { get; set; }

        public virtual ICollection<RequestAgreements> RequestAgreements { get; set; }
    }
}
