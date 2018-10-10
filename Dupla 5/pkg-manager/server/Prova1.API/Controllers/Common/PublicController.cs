using System.Web.Http;

namespace Prova1.API.Controllers.Common
{
    [RoutePrefix("api/public")]
    public class PublicController : ApiControllerBase
    {
        /// <summary>
        /// Informa para o client que está ativa
        /// Útil para validar tokens e para descobrir o estado da API
        /// </summary>
        [HttpGet]
        [Route("is-alive")]
        public IHttpActionResult IsAlive()
        {
            return Ok(true);
        }
    }
}