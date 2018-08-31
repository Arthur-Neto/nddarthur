using System.Web.Http;

namespace Arthur.MF7.WebAPI.Controllers.Common
{
    [RoutePrefix("api/public")]
    public class PublicController : ApiControllerBase
    {
        [HttpGet]
        [Route("is-alive")]
        public IHttpActionResult IsAlive()
        {
            return Ok(true);
        }
    }
}