using Bank.Application.Mapping;
using Bank.WebAPI.Ioc;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace Bank.WebAPI
{
    [ExcludeFromCodeCoverage]
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutoMapperInitializer.Initialize();
            SimpleInjectorContainer.Initialize();
        }
    }
}
