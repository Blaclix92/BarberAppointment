using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BarberAppointment.Identity
{
    public class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var customProfile = new IdentityResource(
            name: "custom.profile",
            displayName: "Custom profile",
            claimTypes: new[] { JwtClaimTypes.Name, JwtClaimTypes.Email, JwtClaimTypes.Role,"userId" });
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                customProfile
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                   ClientId= "native.code",
                   AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                   AllowedScopes = new List<string>()
                   {
                      "DemoApi.full_access",
                      "DemoApi.read_only"

                   },
                   AllowOfflineAccess = true,
                   AllowAccessTokensViaBrowser = true,
                   ClientSecrets = new [] { new Secret("MySecret".Sha256())},
                   AlwaysIncludeUserClaimsInIdToken = true,
                   Enabled = true
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="1",
                    Username = "Admin",
                    Password = "test",
                    Claims = new List<Claim>(){ new Claim(JwtClaimTypes.Role, "admin"), new Claim(JwtClaimTypes.Name, "Reshma Mohan"), new Claim(JwtClaimTypes.Email,"blabl@gamil.com"), new Claim("userId", "99") }
                },
                new TestUser
                {
                    SubjectId="8",
                    Username = "Barber",
                    Password = "test",
                    Claims = new List<Claim>(){ new Claim(JwtClaimTypes.Role, "barber"), new Claim(JwtClaimTypes.Name, "benny Mohan"), new Claim(JwtClaimTypes.Email,"blabl@gamil.com"), new Claim("userId", "2") }
                },
                   new TestUser
                {
                    SubjectId="9",
                    Username = "Barber2",
                    Password = "test",
                    Claims = new List<Claim>(){ new Claim(JwtClaimTypes.Role, "barber"), new Claim(JwtClaimTypes.Name, "beno Mohan"), new Claim(JwtClaimTypes.Email,"blabl@gamil.com"), new Claim("userId", "7") }
                },
                new TestUser
                {
                    SubjectId="1",
                    Username = "Client",
                    Password = "test",
                    Claims = new List<Claim>(){ new Claim(JwtClaimTypes.Role, "client"), new Claim(JwtClaimTypes.Name, "Zhamin Magdalena"), new Claim(JwtClaimTypes.Email,"blabl@gamil.com"), new Claim("userId", "3") }
                },
                new TestUser
                {
                    SubjectId="2",
                    Username = "Client2",
                    Password = "test",
                    Claims = new List<Claim>(){ new Claim(JwtClaimTypes.Role, "client"), new Claim(JwtClaimTypes.Name, "Zhamin Magdalena"), new Claim(JwtClaimTypes.Email,"blabl@gamil.com"), new Claim("userId", "9") }
                },
                     new TestUser
                {
                    SubjectId="3",
                    Username = "Client3",
                    Password = "test",
                    Claims = new List<Claim>(){ new Claim(JwtClaimTypes.Role, "client"), new Claim(JwtClaimTypes.Name, "Zhamin Magdalena"), new Claim(JwtClaimTypes.Email,"blabl@gamil.com"), new Claim("userId", "50") }
                },
                new TestUser
                {
                    SubjectId="4",
                    Username = "Client4",
                    Password = "test",
                    Claims = new List<Claim>(){ new Claim(JwtClaimTypes.Role, "client"), new Claim(JwtClaimTypes.Name, "Zhamin Magdalena"), new Claim(JwtClaimTypes.Email,"blabl@gamil.com"), new Claim("userId", "1") }
                },
                          new TestUser
                {
                    SubjectId="5",
                    Username = "Client5",
                    Password = "test",
                    Claims = new List<Claim>(){ new Claim(JwtClaimTypes.Role, "client"), new Claim(JwtClaimTypes.Name, "Zhamin Magdalena"), new Claim(JwtClaimTypes.Email,"blabl@gamil.com"), new Claim("userId", "5") }
                }


            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                new ApiResource()
                {
                    Name = "DemoApi",
                           Scopes = new List<Scope>()
                {
                new Scope()
                {
                    Name = "DemoApi.full_access",
                    DisplayName = "Full access to DemoApi",
                },
                new Scope
                {
                    Name = "DemoApi.read_only",
                    DisplayName = "Read only access to DemoApi"
                }
            },
                    UserClaims =  { JwtClaimTypes.Name, JwtClaimTypes.Email,  JwtClaimTypes.Role, "userId" },
                }
            };
        }
    }
}
