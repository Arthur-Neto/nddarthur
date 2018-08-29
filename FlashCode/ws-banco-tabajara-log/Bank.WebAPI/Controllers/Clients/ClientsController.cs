using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bank.Application.Features.Clients;
using Bank.Application.Features.Clients.Commands;
using Bank.Application.Features.Clients.Queries;
using Bank.Application.Features.Clients.ViewModels;
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
            var queryStringQuantity = Request.GetQueryNameValuePairs()
                                    .Where(x => x.Key.Equals("quantity"))
                                    .FirstOrDefault();

            ClientQuery query = null;
            if (queryStringQuantity.Key != null)
            {
                query = new ClientQuery();
                query.Quantity = int.Parse(queryStringQuantity.Value);
            }
        
            var result = _clientService.GetAll(query).ProjectTo<ClientViewModel>();

            return HandleQueryable<ClientViewModel>(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var client = _clientService.GetById(id);

            ClientViewModel clientVwModel = new ClientViewModel();

            clientVwModel = Mapper.Map<Client, ClientViewModel>(client);

            return HandleCallback(() => clientVwModel);
        }
        #endregion

        #region POST
        [HttpPost]
        public IHttpActionResult Post(ClientRegisterCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _clientService.Add(cmd));
        }
        #endregion

        #region PUT
        [HttpPut]
        public IHttpActionResult Put(ClientUpdateCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _clientService.Update(cmd));
        }
        #endregion

        #region Delete

        [HttpDelete]
        public IHttpActionResult Delete(ClientRemoveCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _clientService.Remove(cmd));
        }
        #endregion 
    }
}
