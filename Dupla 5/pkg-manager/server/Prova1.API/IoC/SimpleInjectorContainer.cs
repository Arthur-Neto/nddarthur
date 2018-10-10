using System.Web.Http;
using Prova1.Infra.ORM.Contexts;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using Prova1.Application.Features.Orders;
using Prova1.Infra.ORM.Features.Orders;
using Prova1.Domain.Features.Orders;
using Prova1.Domain.Features.Products;
using Prova1.Infra.ORM.Features.Products;
using Prova1.Application.Features.Products;
using System.Diagnostics.CodeAnalysis;

namespace Prova1.API.IoC
{
    /// <summary>
    /// Classe responsável por realizar as configurações de injeção de depêndencia.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class SimpleInjectorContainer
    {
        /// <summary>
        /// Método que inicializa a injeção de depêndencia
        /// </summary>
        public static void Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            RegisterServices(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();
            // Informa que para resolver as depedências nos construtores será usado o container criado
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }


        /// <summary>
        /// Registra todos os serviços que podem ser injetados nos construtores
        /// </summary>
        /// <param name="container">É o contexto de injeção que deve conter as classes que podem ser injetadas</param>
        public static void RegisterServices(Container container)
        {
            container.Register<IOrderService, OrderService>();
            container.Register<IOrderRepository, OrderRepository>();
            container.Register<IProductService, ProductService>();
            container.Register<IProductRepository, ProductRepository>();

            // TODO: Por enquanto estaremos criando o contexto do EF por aqui. Precisaremos trocar por uma Factory
            container.Register<Prova1DbContext>(() => new Prova1DbContext(), Lifestyle.Scoped);
        }
    }
}