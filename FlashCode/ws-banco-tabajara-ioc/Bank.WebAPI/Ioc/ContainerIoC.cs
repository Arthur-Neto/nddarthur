using Bank.Application.Features.Accounts;
using Bank.Application.Features.Clients;
using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Clients;
using Bank.Infra.Data.Base;
using Bank.Infra.Data.Features.Accounts;
using Bank.Infra.Data.Features.Clients;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Configuration;
using System.Web.Http;

namespace Bank.WebAPI.Ioc
{
    public static class ContainerIoC
    {
        public static Container GetContainer()
        {
            string conString = ConfigurationManager.ConnectionStrings["FlashCode_BancoTabajara"].ConnectionString;

            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<BankContext>(() => new BankContext(conString), Lifestyle.Scoped);

            container.Register<ICheckingAccountRepository, CheckingAccountRepository>(Lifestyle.Scoped);
            container.Register<IClientRepository, ClientRepository>(Lifestyle.Scoped);

            container.Register<IClientService, ClientService>(Lifestyle.Scoped);
            container.Register<ICheckingAccountService, CheckingAccountService>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            return container;
        }
    }
}