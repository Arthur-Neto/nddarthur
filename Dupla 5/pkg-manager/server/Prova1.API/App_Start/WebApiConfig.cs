using Prova1.API.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.UriParser;
using Microsoft.OData;
using Prova1.API.Models;
using System.Web.Http.Cors;

namespace Prova1.API.App_Start
{
    /// <summary>
    /// Classe para configurações gerais da API
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class WebApiConfig
    {
        /// <summary>
        /// Método executado ao inicio da API que adiciona configurações e permissionamentos.
        /// </summary>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // TODO: Não usar o * em produção. Alterar para o domínio do cliente de publicação / obter da web.config
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.MapApiRoutes();
            config.EnableOdata();
            config.ConfigureJsonSerialization();
            config.ConfigureXMLSerialization();
            // Adicionamos o atributo global de tratamento de exceções 
            // para responder adequadamente conforme exception de negócio
            config.Filters.Add(new ExceptionHandlerAttribute());
        }

        /// <summary>
        /// Método responsável por habilitar o OData num ApiController
        /// </summary>
        /// <param name="config">É a configuração da api</param>
        private static void EnableOdata(this HttpConfiguration config)
        {
            // Web API Enable OData
            config.Count().Select().Filter().OrderBy().MaxTop(null);
            config.AddODataQueryFilter();
            config.EnableDependencyInjection(builder =>
            {
                /* string as enum, substitui o antigo EnableEnumPrefixFree. Converte a String que vem no FiltroOdata para o Enum correspondente*/
                builder.AddService<ODataUriResolver>(ServiceLifetime.Singleton, sp => new StringAsEnumResolver() { EnableCaseInsensitive = true });
            });
        }

        /// <summary>
        /// Método responsável por configurar as rotas de api
        /// </summary>
        /// <param name="config"></param>
        private static void MapApiRoutes(this HttpConfiguration config)
        {
            // Habilita o uso do Atributo de [Route]
            config.MapHttpAttributeRoutes();
            // Configura o uso de [Route]
            config.Routes.MapHttpRoute(
                name: "Prova1.API",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    action = RouteParameter.Optional
                }
            );
        }

        /// <summary>
        /// Método responsável por configurar a forma de serialização em JSON
        /// </summary>
        /// <param name="config"></param>
        private static void ConfigureJsonSerialization(this HttpConfiguration config)
        {
            var jsonSerializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSerializerSettings.Formatting = Formatting.None;
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            // Define que o Content-Type na resposta é o application/json
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue(MediaTypes.Json));
        }

        /// <summary>
        /// Método responsável por configurar a forma de serialização em XML
        /// </summary>
        /// <param name="config"></param>
        private static void ConfigureXMLSerialization(this HttpConfiguration config)
        {
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
    }
}