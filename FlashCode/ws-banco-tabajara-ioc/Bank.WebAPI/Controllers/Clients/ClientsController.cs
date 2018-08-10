using Bank.Application.Features.Clients;
using Bank.Domain.Features.Clients;
using Bank.WebAPI.Controllers.Common;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Bank.WebAPI.Controllers.Clients
{
    [RoutePrefix("api/clients")]
    public class ClientsController : ApiControllerBase
    {
        public IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        #region GET
        [HttpGet]
        public IHttpActionResult Get()
        {

            var queryString = Request.GetQueryNameValuePairs()
                                    .Where(x => x.Key.Equals("quantity"))
                                    .FirstOrDefault();
            int? quantity = null;

            if (queryString.Key != null)
                quantity = int.Parse(queryString.Value);

            var query = _clientService.GetAll(quantity);

            return HandleQueryable<Client>(query);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var client = _clientService.GetById(id);
            return HandleCallback(() => client);
        }
        #endregion

        #region POST
        [HttpPost]
        public IHttpActionResult Post(Client client)
        {
            return HandleCallback(() => _clientService.Add(client));
        }
        #endregion

        #region PUT
        [HttpPut]
        public IHttpActionResult Put(Client client)
        {
            return HandleCallback(() => _clientService.Update(client));
        }
        #endregion

        #region Delete

        [HttpDelete]
        public IHttpActionResult Delete(Client client)
        {
            return HandleCallback(() => _clientService.Remove(client));

        }
        #endregion 
    }
}
