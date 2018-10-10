using Projeto_NFe.API.IoC;
using Projeto_NFe.Application.Mapeador;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace Projeto_NFe.API
{
    [ExcludeFromCodeCoverage]
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Registrar);
            SimpleInjectorContainer.Initialize();
            InicializadorAutoMapper.Inicializar();
        }
    }
}
