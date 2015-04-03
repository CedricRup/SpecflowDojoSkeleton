using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using WebApi;

[assembly: OwinStartup(typeof(Startup))]
namespace WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Configuration(app, GlobalConfiguration.Configuration);
        }

        public void Configuration(IAppBuilder app, HttpConfiguration configuration)
        {

            System.Diagnostics.Trace.TraceInformation("Démarrage de l'application");
            
            configuration.SetupIoc();

            WebApiConfig.Register(configuration);
            app.UseWebApi(configuration);

            app.Use((o, next) =>
            {
                throw new HttpException(404, "That doesn't exist!");
            });

            configuration.EnsureInitialized();

            System.Diagnostics.Trace.TraceInformation("Démarrage OK");
        }
    }
}
