using IdentityModel.Client;
using Resourceedge.Appraisal.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Services
{
    public class TokenAccessorService : ITokenAccesor
    {
        private readonly HttpClient httpclient;

        public DiscoveryDocumentResponse DiscoveryDocument { get; set; }
        public TokenResponse TokenResponse { get; set; }

        public TokenAccessorService(IHttpClientFactory _httpclient)
        {
            httpclient = _httpclient.CreateClient("discoveryEndpoint");
            DiscoveryDocument = httpclient.GetDiscoveryDocumentAsync(httpclient.BaseAddress.AbsoluteUri).GetAwaiter().GetResult();

            TokenResponse = httpclient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = DiscoveryDocument.TokenEndpoint,
                ClientId = "edge_appraisal_subsystem",
                ClientSecret = "edge_appraisal_subsystem_secret",
                Scope = "Employee",
            }).GetAwaiter().GetResult();
        }
    }
}
