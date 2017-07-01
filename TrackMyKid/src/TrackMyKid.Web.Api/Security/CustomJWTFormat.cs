using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;

namespace TrackMyKid.Web.Api.Security
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string _issuer;
        private readonly string _symmetricBase64EncodedKey;

        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
            _symmetricBase64EncodedKey = ConfigurationManager.AppSettings["SymmetricKey"];
        }

        public string Protect(AuthenticationTicket authenticationTicket)
        {
            if (authenticationTicket == null)
            {
                throw new ArgumentNullException(nameof(authenticationTicket));
            }

            string audienceId = "trackmykid_mobile";//authenticationTicket.Properties.Dictionary.ContainsKey(AudiencePropertyKey) ? 
            //    authenticationTicket.Properties.Dictionary[AudiencePropertyKey] : null;

            if (string.IsNullOrWhiteSpace(audienceId))
                throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience");

            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(_symmetricBase64EncodedKey));
            var signingKey = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);

            var issued = authenticationTicket.Properties.IssuedUtc;
            var expires = authenticationTicket.Properties.ExpiresUtc;

            var token = new JwtSecurityToken(
                _issuer, 
                audienceId, 
                authenticationTicket.Identity.Claims, 
                issued?.UtcDateTime, 
                expires?.UtcDateTime, 
                signingKey);

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.WriteToken(token);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}