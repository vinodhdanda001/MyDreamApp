using System.Web.Http;
using Autofac;
using Microsoft.Owin;
using Owin;
using TrackMyKid.Web.Api;

[assembly: OwinStartup(typeof(Startup))]

namespace TrackMyKid.Web.Api
{
    public class Startup
    {
        protected static IContainer Container { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();

            IContainer containerObject;

            DependencyInjectionConfig.RegisterContainer(app, configuration, out containerObject);
            Container = containerObject;

            WebApiConfig.Register(configuration);
            app.UseWebApi(configuration);
        }
    }
}
