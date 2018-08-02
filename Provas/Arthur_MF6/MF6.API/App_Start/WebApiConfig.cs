using MF6.API.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MF6.API {

    /// <summary>
    /// Classe para configurações gerais da API
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class WebApiConfig {

        /// <summary>
        /// Método executado ao inicio da API que adiciona configurações e permissionamentos.
        /// </summary>
        public static void Register(HttpConfiguration config) {
            // Web API configuration and services
            config.MapApiRoutes();
            config.ConfigureJsonSerialization();
            config.ConfigureXMLSerialization();
            // Adicionamos o atributo global de tratamento de exceções
            // para responder adequadamente conforme exception de negócio
            config.Filters.Add(new ExceptionHandlerAttribute());
        }

        /// <summary>
        /// Método responsável por configurar as rotas de api
        /// </summary>
        /// <param name="config"></param>
        private static void MapApiRoutes(this HttpConfiguration config) {
            // Habilita o uso do Atributo de [Route]
            config.MapHttpAttributeRoutes();
            // Configura o uso de [Route]
            config.Routes.MapHttpRoute(
                name: "MF6.API",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new {
                    id = RouteParameter.Optional,
                    action = RouteParameter.Optional
                }
            );
        }

        /// <summary>
        /// Método responsável por configurar a forma de serialização em JSON
        /// </summary>
        /// <param name="config"></param>
        private static void ConfigureJsonSerialization(this HttpConfiguration config) {
            var jsonSerializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSerializerSettings.Formatting = Formatting.None;
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            // Define que o Content-Type na resposta é o application/json
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }

        /// <summary>
        /// Método responsável por configurar a forma de serialização em XML
        /// </summary>
        /// <param name="config"></param>
        private static void ConfigureXMLSerialization(this HttpConfiguration config) {
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
    }
}