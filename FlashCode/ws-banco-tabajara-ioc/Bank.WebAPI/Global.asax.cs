using Bank.Application.Features.Accounts;
using Bank.Application.Features.Clients;
using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Clients;
using Bank.Infra.Data.Base;
using Bank.Infra.Data.Features.Accounts;
using Bank.Infra.Data.Features.Clients;
using Bank.WebAPI.Ioc;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace Bank.WebAPI
{
    [ExcludeFromCodeCoverage]
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = ContainerIoC.GetContainer();

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
