using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class AspNetUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
        public string AppUserId { get; set; }

        public virtual AspNetUsers AppUser { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
