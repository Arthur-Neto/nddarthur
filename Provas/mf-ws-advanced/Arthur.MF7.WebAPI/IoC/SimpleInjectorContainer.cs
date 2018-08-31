using Arthur.MF7.Application.Features.Authentication;
using Arthur.MF7.Application.Features.Employees;
using Arthur.MF7.Application.Features.Spendings;
using Arthur.MF7.Domain.Features.Employees;
using Arthur.MF7.Domain.Features.Spendings;
using Arthur.MF7.Domain.Features.Users;
using Arthur.MF7.Infra.ORM.Base;
using Arthur.MF7.Infra.ORM.Features.Employees;
using Arthur.MF7.Infra.ORM.Features.Spendings;
using Arthur.MF7.Infra.ORM.Features.Users;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace Arthur.MF7.WebAPI.IoC
{
    [ExcludeFromCodeCoverage]
    public static class SimpleInjectorContainer
    {
        public static Container Container { get; private set; }

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
            container.Register<IEmployeeRepository, EmployeeRepository>();
            container.Register<ISpendingRepository, SpendingRepository>();

            container.Register<ISpendingService, SpendingService>();
            container.Register<IEmployeeService, EmployeeService>();

            container.Register<IUserRepository, UserRepository>();

            container.Register<AuthenticationService>(() => new AuthenticationService(Container.GetInstance<IUserRepository>()));
            container.Register<MF7Context>(() => new MF7Context(), Lifestyle.Singleton);
        }
    }
}