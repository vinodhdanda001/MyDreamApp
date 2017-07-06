using System.Web.Http;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TrackMyKid.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //Route Configuration
            config.Routes.MapHttpRoute(
                name: "DefaultA",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultB",
                routeTemplate: "api/{controller}/{orgId}/{routeId}/{tripId}",
                defaults: new { orgId = RouteParameter.Optional
                                , routeId = RouteParameter.Optional
                                , tripId = RouteParameter.Optional, }
            );

            //
            // Adding the custom filter 
            config.Filters.Add(new ExecptionHandler.MethodExceptionHandlingAttribute());
            config.Services.Replace(typeof(IHttpActionInvoker), new ExecptionHandler.CustomApiControllerActionInvoker());
            //Only JSON OUPUT
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

        }
    }
}
