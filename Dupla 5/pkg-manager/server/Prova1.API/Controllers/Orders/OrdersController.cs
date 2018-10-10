using AutoMapper;
using Microsoft.AspNet.OData.Query;
using Prova1.API.Controllers.Common;
using Prova1.API.Filters;
using Prova1.Application.Features.Orders;
using Prova1.Application.Features.Orders.Commands;
using Prova1.Application.Features.Orders.Queries;
using Prova1.Application.Features.Orders.ViewModels;
using Prova1.Domain;
using Prova1.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Prova1.API.Controllers.Orders
{
    /// <summary>
    /// Controlador de Orders
    /// 
    /// Essa classe é responsável por prover os dados relacionados a entidade Order.
    /// 
    /// </summary>
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiControllerBase
    {
        private readonly IOrderService _ordersService;

        // Usamos IoC aqui para injetar a instância única (singleton) nesse controller
        public OrdersController(IOrderService ordersService) : base()
        {
            _ordersService = ordersService;
        }

        #region HttpGet

        /// <summary>
        /// Interface para obter uma lista geral de orders
        /// </summary>
        /// <returns>Retorna uma lista de orders</returns>
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Order> queryOptions)
        {
            return HandleQueryable<Order, OrderViewModel>(_ordersService.GetAll(), queryOptions);
        }

        /// <summary>
        /// Interface para obter uma order específico pelo id
        /// </summary>
        /// <param name="id">É o id da order para realizar a pesquisa. Provém diretamente da url pela configuração do Route</param>
        /// <returns>Retorna o order com id correspondente ao paramêtro orderId</returns>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleQuery<Order, OrderViewModel>(_ordersService.GetById(id));
        }
        #endregion HttpGet

        #region HttpPost
        /// <summary>
        /// Interface para cadastro de orders
        /// </summary>
        /// <param name="orderCmd">É a order que será cadastrado no banco de dados. Provém do corpo da requisição (body)</param>
        /// <returns>Retorna um objeto com os erros acontecidos na operação. Em caso de sucesso, não há propriedades. </returns>
        [HttpPost]
        public IHttpActionResult Post(OrderRegisterCommand orderCmd)
        {
            var validator = orderCmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_ordersService.Add(orderCmd));
        }

        #endregion HttpPost

        #region HttpPut
        /// <summary>
        /// Interface para editar uma order
        /// </summary>
        /// <param name="command">É o order que será atualizada no banco de dados. Provém do corpo da requisição (body)</param>
        /// <returns>Retorna um objeto com os erros acontecidos na operação. Em caso de sucesso, não há propriedades. </returns>
        [HttpPut]
        public IHttpActionResult Update(OrderUpdateCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_ordersService.Update(command));
        }

        #endregion HttpPut

        #region HttpDelete
        /// <summary>
        /// Interface para remover uma order
        /// </summary>
        /// <param name="command">É a order que será removido no banco de dados. Provém do corpo da requisição (body)</param>
        /// <returns>Retorna um objeto com os erros acontecidos na operação. Em caso de sucesso, não há propriedades. </returns>
        [HttpDelete]
        public IHttpActionResult Delete(OrderRemoveCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_ordersService.Remove(command));
        }

        #endregion HttpDelete
    }
}