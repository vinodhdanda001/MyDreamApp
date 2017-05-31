using System.Web.Http.Validation;
using Autofac;
using FluentValidation.WebApi;
using TrackMyKid.DataLayer.Interfaces;
using TrackMyKid.DataLayer.Services;

namespace TrackMyKid.Web.Api.IoC
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<FluentValidationModelValidatorProvider>()
                .As<ModelValidatorProvider>();

            builder.RegisterType<GeoLocationService>()
                .As<IGeoLocationService>()
                .InstancePerDependency();

            builder.RegisterType<LoginDataService>()
                .As<ILoginDataService>()
                .InstancePerDependency();

            builder.RegisterType<MemberService>()
                .As<IMemberService>()
                .InstancePerDependency();

            builder.RegisterType<RegisterDataService>()
                .As<IRegisterDataService>()
                .InstancePerDependency();

            builder.RegisterType<RouteService>()
                .As<IRouteService>()
                .InstancePerDependency();

            builder.RegisterType<TripDataService>()
                .As<ITripDataService>()
                .InstancePerDependency();
        }
    }
}