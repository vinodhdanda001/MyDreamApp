using System;
using System.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;

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
            const string signatureAlgorithm = "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256";
            const string digestAlgorithm = "http://www.w3.org/2001/04/xmlenc#sha256";

            if (authenticationTicket == null)
            {
                throw new ArgumentNullException(nameof(authenticationTicket));
            }

            const string audienceId = "http://trackmykid.webapi.com/api/";
            var securityKey = new InMemorySymmetricSecurityKey(TextEncodings.Base64Url.Decode(_symmetricBase64EncodedKey));

            var issued = authenticationTicket.Properties.IssuedUtc;
            var expires = authenticationTicket.Properties.ExpiresUtc;

            var identity = new GenericIdentity("user");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(identity, authenticationTicket.Identity.Claims),
                TokenIssuerName = _issuer,
                AppliesToAddress = audienceId,
                Lifetime = new Lifetime(issued?.UtcDateTime, expires?.UtcDateTime),
                SigningCredentials = new SigningCredentials(securityKey, signatureAlgorithm, digestAlgorithm),
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}