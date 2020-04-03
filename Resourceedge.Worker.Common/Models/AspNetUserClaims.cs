using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resourceedge.Worker.Common.Models
{
    public partial class AspNetUserClaims
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        //public string SystemId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
