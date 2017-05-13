using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using TrackMyKid.Web.Api.IoC;

namespace TrackMyKid.Web.Api
{
    public class DependencyInjectionConfig
    {
        public static void RegisterContainer(IAppBuilder app, HttpConfiguration configuration, out IContainer container)
        {
            var builder = new ContainerBuilder();
           
            //builder.RegisterModule<LoggingModule>();
            builder.RegisterModule<WebApiModule>();

            container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(configuration);
        }
    }
}