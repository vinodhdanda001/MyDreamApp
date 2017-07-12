using System;
using System.Configuration;
using System.Web.Http;
using Autofac;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
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
        protected readonly string Issuer;

        protected static IContainer Container { get; private set; }

        public Startup()
        {
            Issuer = ConfigurationManager.AppSettings["Issuer"];
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
                AccessTokenFormat = new CustomJwtFormat(Issuer)
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            app.UseJwtBearerAuthentication(
               new JwtBearerAuthenticationOptions
               {
                   AuthenticationMode = AuthenticationMode.Active,
                   AllowedAudiences = new []{ "http://localhost:58735/api/" },
                   IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                   {
                        new SymmetricKeyIssuerSecurityTokenProvider(
                            Issuer,
                            TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["SymmetricKey"]))
                   }
               });
        }
    }
}
