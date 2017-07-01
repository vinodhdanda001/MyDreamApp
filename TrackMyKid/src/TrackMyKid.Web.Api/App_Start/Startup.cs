using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using Autofac;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TrackMyKid.Web.Api;
using TrackMyKid.Web.Api.Security;

[assembly: OwinStartup(typeof(Startup))]

namespace TrackMyKid.Web.Api
{
    public class Startup
    {
        public readonly List<string> Audience;
        protected readonly string Issuer;

        protected static IContainer Container { get; private set; }

        public Startup()
        {
            Issuer = ConfigurationManager.AppSettings["Issuer"];
            Audience = SplitSemicolonSeperatedValues(ConfigurationManager.AppSettings["Audience"]);
        }

        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();

            IContainer containerObject;

            DependencyInjectionConfig.RegisterContainer(app, configuration, out containerObject);
            Container = containerObject;

            ConfigureOAuth(app);
            app.UseCors(CorsOptions.AllowAll);
            WebApiConfig.Register(configuration);
            app.UseWebApi(configuration);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat("trackmykid_oauthserver")
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            app.UseJwtBearerAuthentication(
               new JwtBearerAuthenticationOptions
               {
                   AuthenticationMode = AuthenticationMode.Active,
                   AllowedAudiences = Audience,
                   IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                   {
                        new SymmetricKeyIssuerSecurityTokenProvider(
                            Issuer,
                            ConfigurationManager.AppSettings["SymmetricKey"])
                   }
               });
        }

        private static List<string> SplitSemicolonSeperatedValues(string commaSeperatedString)
        {
            var values = new List<string>();
            if (!string.IsNullOrEmpty(commaSeperatedString))
                values = commaSeperatedString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim())
                    .Where(x => !string.IsNullOrEmpty(x)).ToList();
            return values;
        }
    }
}
