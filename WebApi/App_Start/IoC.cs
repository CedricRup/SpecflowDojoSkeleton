using System.Net.Http;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Database;
using Model;
using WebApi.Controllers;

namespace WebApi
{
    public static class IoC
    {
        public static void SetupIoc(this HttpConfiguration configuration)
        {
            var container = BuildContainer(configuration);
            SetupConfiguration(container, configuration);
        }

        private static void SetupConfiguration(ILifetimeScope container, HttpConfiguration configuration)
        {
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer BuildContainer(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof (RituelController).Assembly).InstancePerRequest();
            builder.RegisterHttpRequestMessage(configuration);
            builder.Register(ctx => ctx.Resolve<HttpRequestMessage>().GetOwinContext().Authentication).InstancePerRequest();

            var partieStore = new RituelStore();
            builder.RegisterInstance(partieStore).AsImplementedInterfaces();

            var villageStore = new VillageStore();
            builder.RegisterInstance(villageStore).AsImplementedInterfaces();

            var dailyStore = new PlanActionStore();
            builder.RegisterInstance(dailyStore).AsImplementedInterfaces();

            return builder.Build();
        }
    }
}