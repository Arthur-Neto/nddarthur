using MF6.API.Controllers.Common;
using System.Web.Http;

namespace MF6.API.Controllers.Testes {

    [RoutePrefix("api/testes")]
    public class TestesController : ApiControllerBase {

        [HttpGet]
        [Route("{id:long}")]
        public IHttpActionResult GetById(long id) {
            return HandleCallback(() => "O ID enviado foi: " + id);
        }
    }
}