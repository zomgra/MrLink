using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace MrLink.IdentityServer
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes()
        {
            yield return new ApiScope("MLinkWebAPI", "Web API");
        }
        public static IEnumerable<IdentityResource> IdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
        }
        public static IEnumerable<ApiResource> ApiResources()
        {
            yield return new ApiResource("MLinkWebAPI", "Web API", new[] { JwtClaimTypes.Name })
            {
                Scopes = { "MLinkWebAPI" }
            };
        }
        public static IEnumerable<Client> Clients()
        {
            yield return new Client()
            {
                ClientId = "mlink-web-api",
                ClientName = "MLink Web",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                //  RequirePkce = false,
                AllowedCorsOrigins = new[]
                {
                    "https://localhost:7200"
                },
                RedirectUris =
                {
                    "https://localhost:7200/signin-oidc"
                },
                PostLogoutRedirectUris =
                {
                    "https://localhost:7200/signout-oidc",
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "MLinkWebAPI"
                },
                RequireConsent = false,

                AccessTokenLifetime = 500,

                AllowOfflineAccess = true,
                AllowAccessTokensViaBrowser = true,
            };
        }
    }
}
