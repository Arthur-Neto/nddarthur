using Arthur.MF7.WebAPI.Filters;
using Arthur.MF7.WebAPI.Logger;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace Arthur.MF7.WebAPI
{
    [ExcludeFromCodeCoverage]
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapApiRoutes();
            config.ConfigureJsonSerialization();
            config.ConfigureXMLSerialization();
            config.Filters.Add(new ExceptionHandlerAttribute());
            config.MessageHandlers.Add(new CustomLogHandler());
        }

        private static void MapApiRoutes(this HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "Arthur.MF7.WebAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    action = RouteParameter.Optional
                }
            );
        }

        private static void ConfigureJsonSerialization(this HttpConfiguration config)
        {
            Newtonsoft.Json.JsonSerializerSettings jsonSerializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSerializerSettings.Formatting = Formatting.None;
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }

        private static void ConfigureXMLSerialization(this HttpConfiguration config)
        {
            config.Formatters.XmlFormatter.WriterSettings.Encoding = Encoding.UTF8;
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
    }
}
