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

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _server = WebApp.Start<StartupSpecFlow>("http://localhost:12345");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            if (_server != null)
            {
                _server.Dispose();
            }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
        }

        [AfterScenario]
        public void AfterScenario()
        {
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
