using Projeto_NFe.Application.Funcionalidades.Destinatarios;
using Projeto_NFe.Application.Funcionalidades.Emitentes;
using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais;
using Projeto_NFe.Application.Funcionalidades.Produtos;
using Projeto_NFe.Application.Funcionalidades.Transportadoras;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Data.Base;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Destinatarios;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Emitentes;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Transportadoras;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace Projeto_NFe.API.IoC
{
    [ExcludeFromCodeCoverage]
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

        public static void RegisterServices(Container container)
        {
            container.Register<IDestinatarioServico, DestinatarioServico>();
            container.Register<IEmitenteServico, EmitenteServico>();
            container.Register<INotaFiscalServico, NotaFiscalServico>();
            container.Register<IProdutoServico, ProdutoServico>();
            container.Register<ITransportadorServico, TransportadorServico>();

            container.Register<IDestinatarioRepositorio, DestinatarioRepositorioSql>();
            container.Register<IEmitenteRepositorio, EmitenteRepositorioSql>();
            container.Register<IEnderecoRepositorio, EnderecoRepositorioSql>();
            container.Register<INotaFiscalRepositorio, NotaFiscalRepositorioSql>();
            container.Register<INotaFiscalEmitidaRepositorio, NotaFiscalEmitidaRepositorioSql>();
            container.Register<IProdutoRepositorio, ProdutoRepositorioSql>();
            container.Register<ITransportadorRepositorio, TransportadorRepositorioSql>();
            container.Register<IProdutoNotaFiscalRepositorio, ProdutoNotaFiscalRepositorioSql>();

            container.Register<ProjetoNFeContexto>(() => new ProjetoNFeContexto(), Lifestyle.Scoped);
        }
    }
}