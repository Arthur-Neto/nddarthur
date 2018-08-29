using Bank.Application.Features.Authentication;
using Bank.Application.Mapping;
using Bank.WebAPI.App_Start;
using Bank.WebAPI.Ioc;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

[assembly: OwinStartup(typeof(Bank.WebAPI.Startup))]
namespace Bank.WebAPI
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