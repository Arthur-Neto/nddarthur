using Bank.Application.Features.Accounts;
using Bank.Application.Features.Clients;
using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Clients;
using Bank.Infra.Data.Base;
using Bank.Infra.Data.Features.Accounts;
using Bank.Infra.Data.Features.Clients;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace Bank.WebAPI.Ioc
{
    public static class SimpleInjectorContainer
    {
        public static void Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            RegisterServices(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void RegisterServices(Container container)
        {
            container.Register<ICheckingAccountRepository, CheckingAccountRepository>(Lifestyle.Scoped);
            container.Register<IClientRepository, ClientRepository>(Lifestyle.Scoped);

            container.Register<IClientService, ClientService>(Lifestyle.Scoped);
            container.Register<ICheckingAccountService, CheckingAccountService>(Lifestyle.Scoped);

            container.Register<BankContext>(() => new BankContext(), Lifestyle.Scoped);
        }
    }
}