﻿using System.Net.Http;
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

            builder.RegisterApiControllers(typeof (DummyController).Assembly).InstancePerRequest();
            builder.RegisterHttpRequestMessage(configuration);
            builder.Register(ctx => ctx.Resolve<HttpRequestMessage>().GetOwinContext().Authentication).InstancePerRequest();

            var developpeurStore = new DeveloppeurStore();
            builder.RegisterInstance(developpeurStore);

            var partieStore = new ProjetStore();
            builder.RegisterInstance(partieStore).AsImplementedInterfaces();

            
            var dummyStore = new DummyStore();
            dummyStore.Register(new Dummy{Name = "Franklin"});
            builder.RegisterInstance(dummyStore);

            return builder.Build();
        }
    }
}