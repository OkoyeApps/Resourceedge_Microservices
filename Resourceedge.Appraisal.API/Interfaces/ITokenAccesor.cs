using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public interface ITokenAccesor
    {
        DiscoveryDocumentResponse DiscoveryDocument { get; set; }
        TokenResponse  TokenResponse { get; set; }
    }
}
