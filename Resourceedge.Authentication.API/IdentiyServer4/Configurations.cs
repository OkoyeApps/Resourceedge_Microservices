using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.API.IdentiyServer4
{
    public class Configurations
    {
        //information about the user, that will be used in the id_token
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "edge_priviledge_appraisal",
                    UserClaims = {"privilege_appraisal"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            //Claims added here are added to the access_token
            return new List<ApiResource>
            {
                new ApiResource("Appraisal", new string[] { "privilege_appraisal"}),
                new ApiResource("Employee", new string[] {}),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("edge_employee_subsystem_secret".Sha256()) },
                    ClientId = "edge_employee_subsystem",
                },
                new Client
                {
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("edge_appraisal_subsystem_secret".Sha256()) },
                    ClientId = "edge_appraisal_subsystem",
                    AllowedScopes = { "Employee" }
                },

                 new Client
                 {
                     ClientId ="edge_client_appraisal",
                     AllowedGrantTypes = GrantTypes.Implicit,
                     AllowedScopes = { 
                         IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile,
                         "Employee", "Appraisal", "edge_priviledge_appraisal"
                     },
                     RedirectUris = {"http://localhost:3000/auth/redirect", "https://staging-resourceedge.herokuapp.com/auth/redirect", "https://resourceedge.herokuapp.com/auth/redirect" },
                     AllowAccessTokensViaBrowser = true,
                     RequireConsent = false,
                     PostLogoutRedirectUris = {"http://localhost:3000", "https://staging-resourceedge.herokuapp.com", "https://resourceedge.herokuapp.com"},
                     AccessTokenLifetime = 2,
                     //Allow CORS
                     AllowedCorsOrigins = { "http://localhost:3000", "https://staging-resourceedge.herokuapp.com", "https://resourceedge.herokuapp.com" },

                 }



                 
            };
        }

    }
}
