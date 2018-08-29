using Bank.Application.Features.Accounts;
using Bank.Application.Features.Authentication;
using Bank.Application.Features.Clients;
using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Clients;
using Bank.Domain.Features.Users;
using Bank.Infra.Data.Base;
using Bank.Infra.Data.Features.Accounts;
using Bank.Infra.Data.Features.Clients;
using Bank.Infra.Data.Features.Users;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace Bank.WebAPI.Ioc
{
    [ExcludeFromCodeCoverage]
    public static class SimpleInjectorContainer
    {
        public static Container Container { get; set; }

        public static void Initialize()
        {
            Container = new Container();

            RegisterServices(Container);

            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            Container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);

            using (AsyncScopedLifestyle.BeginScope(Container))
            {
                AuthenticationService instance = Container.GetInstance<AuthenticationService>();
            }
        }

        private static void RegisterServices(Container container)
        {
            container.Register<ICheckingAccountRepository, CheckingAccountRepository>();
            container.Register<IClientRepository, ClientRepository>();

            container.Register<IClientService, ClientService>();
            container.Register<ICheckingAccountService, CheckingAccountService>();

            container.Register<IUserRepository, UserRepository>();

            container.Register<AuthenticationService>(() => new AuthenticationService(Container.GetInstance<IUserRepository>()));
            container.Register<BankContext>(() => new BankContext(), Lifestyle.Singleton);
        }
    }
}