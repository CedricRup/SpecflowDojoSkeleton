using System;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;
using TechTalk.SpecFlow;
using WebApi;

namespace Specs
{
    [Binding]
    public class Hooks
    {
        private static IDisposable _server;

        [BeforeScenario]
        public static void StartEmbeddedServer()
        {
            _server = WebApp.Start<StartupSpecFlow>("http://localhost:12345");
        }

        [AfterScenario]
        public static void ShutdownEmbeddedServer()
        {
            if (_server != null)
            {
                _server.Dispose();
            }
        }

    }

    public class StartupSpecFlow
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            new Startup().Configuration(app, configuration);
        }
    }
}
