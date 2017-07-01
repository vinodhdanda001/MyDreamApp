using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

namespace TrackMyKid.Web.Api.Security
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //TODO: Validate context.Username and context.Password from the DB 
            //if (context.UserName != context.Password)
            //{
            //    context.SetError("invalid_grant", "The user name or password is incorrect");
            //    return Task.FromResult<object>(null);
            //}

            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));

            //TODO: Get role from DB and create a claim 
            identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                {
                    "audience", context.ClientId ?? string.Empty
                }
            });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }
    }
}