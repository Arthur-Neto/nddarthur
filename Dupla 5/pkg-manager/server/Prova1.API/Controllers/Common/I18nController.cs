using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Prova1.API.Controllers.Common
{
    /// <summary>
    /// Controlador de i18n (internationalization)
    /// 
    /// Essa classe é responsável por prover as resources de tradução apra o client
    /// 
    /// </summary>
    [RoutePrefix("api/i18n")]
    public class I18nController : ApiControllerBase
    {

        /// <summary>
        /// Interface para obter as resources de uma linguagem específica
        /// </summary>
        /// <param name="lang">É a linguagem que deseja obter as resources. Provém diretamente da url pela configuração do Route</param>
        /// <returns>Retorna as resources de acordo com a linguagem</returns>
        [HttpGet]
        [Route("{lang}")]
        [ResponseType(typeof(string))]
        [AllowAnonymous]
        public HttpResponseMessage Get([FromUri] string lang)
        {
            // Configs
            var result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StringContent("");
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return result;
        }
    }
}