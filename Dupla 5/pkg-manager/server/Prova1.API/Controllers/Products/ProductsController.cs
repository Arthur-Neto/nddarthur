using Microsoft.AspNet.OData.Query;
using Prova1.API.Controllers.Common;
using Prova1.API.Filters;
using Prova1.Application.Features.Products;
using Prova1.Application.Features.Products.Commands;
using Prova1.Application.Features.Products.Queries;
using Prova1.Application.Features.Products.ViewModels;
using Prova1.Domain.Exceptions;
using Prova1.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Prova1.API.Controllers.Products
{
    /// <summary>
    /// Controlador de Products
    /// 
    /// Essa classe é responsável por prover os dados relacionados a entidade Product.
    /// </summary>
    [RoutePrefix("api/products")]
    public class ProductsController : ApiControllerBase
    {
        private readonly IProductService _productService;

        // Usamos IoC aqui para injetar a instância única (singleton) nesse controller
        public ProductsController(IProductService productService) : base()
        {
            _productService = productService;
        }

        #region HttpGet
        /// <summary>
        /// Interface para obter uma lista geral de products
        /// </summary>
        /// <returns>Retorna uma lista de products</returns>
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Product> queryOptions)
        {
            var queryString = Request.GetQueryNameValuePairs()
                                    .Where(x => x.Key.Equals("size"))
                                    .FirstOrDefault();
 
            var query = default(IQueryable<Product>);
            int size = 0;
            if (queryString.Key != null && int.TryParse(queryString.Value, out size))
            {
                query = _productService.GetAll(new ProductQuery(size));
            }
            else
                query = _productService.GetAll();

            return HandleQueryable<Product, ProductViewModel>(query, queryOptions);
        }

        /// <summary>
        /// Interface para obter uma product específico pelo id
        /// </summary>
        /// <param name="id">É o id da product para realizar a pesquisa. Provém diretamente da url pela configuração do Route</param>
        /// <returns>Retorna o product com id correspondente ao paramêtro productId</returns>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleQuery<Product, ProductViewModel>(_productService.GetById(id));
        }
        #endregion HttpGet

        #region HttpPost
        /// <summary>
        /// Interface para cadastro de products
        /// </summary>
        /// <param name="productCmd">É a product que será cadastrado no banco de dados. Provém do corpo da requisição (body)</param>
        /// <returns>Retorna um objeto com os erros acontecidos na operação. Em caso de sucesso, não há propriedades. </returns>
        [HttpPost]
        public IHttpActionResult Post(ProductRegisterCommand productCmd)
        {
            var validator = productCmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_productService.Add(productCmd));
        }

        #endregion HttpPost

        #region HttpPut
        /// <summary>
        /// Interface para editar uma product
        /// </summary>
        /// <param name="command">É o product que será atualizada no banco de dados. Provém do corpo da requisição (body)</param>
        /// <returns>Retorna um objeto com os erros acontecidos na operação. Em caso de sucesso, não há propriedades. </returns>
        [HttpPut]
        public IHttpActionResult Update(ProductUpdateCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_productService.Update(command));
        }

        #endregion HttpPut

        #region HttpDelete
        /// <summary>
        /// Interface para remover um product
        /// </summary>
        /// <param name="command">É o product que será removido no banco de dados. Provém do corpo da requisição (body)</param>
        /// <returns>Retorna um objeto com os erros acontecidos na operação. Em caso de sucesso, não há propriedades. </returns>
        [HttpDelete]
        public IHttpActionResult Delete(ProductRemoveCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_productService.Remove(command));
        }

        #endregion HttpDelete
    }
}