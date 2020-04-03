using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.Domain.Interfaces
{
   public  interface IExternalServiceInterface
    {
        Task<bool> AddMultipleUserClaimsByEmail(Dictionary<string, IEnumerable<Claim>> userClaims);
    }
}
