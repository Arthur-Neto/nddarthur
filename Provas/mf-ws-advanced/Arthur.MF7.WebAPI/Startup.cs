using Arthur.MF7.Application.Mapping;
using Arthur.MF7.WebAPI.App_Start;
using Arthur.MF7.WebAPI.IoC;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

[assembly: OwinStartup(typeof(Arthur.MF7.WebAPI.Startup))]
namespace Arthur.MF7.WebAPI
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutoMapperInitializer.Initialize();
            SimpleInjectorContainer.Initialize();

            HttpConfiguration config = new HttpConfiguration();
            app.UseCors(CorsOptions.AllowAll);
            OAuthConfig.ConfigOAuth(app);
            app.UseWebApi(config);
        }
    }
}