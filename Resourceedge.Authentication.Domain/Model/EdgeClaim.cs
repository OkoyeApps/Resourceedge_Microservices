using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Resourceedge.Authentication.Domain.Model
{
    public class EdgeClaim : Claim
    {
        public EdgeClaim(string type, string value, string systemId) : base(type, value, systemId)
        {
            this.SystemID = systemId;
        }

        public string SystemID { get; set; }

    }
}
