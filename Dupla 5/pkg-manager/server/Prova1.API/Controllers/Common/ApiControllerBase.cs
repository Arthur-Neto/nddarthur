using Prova1.API.Exceptions;
using Prova1.Domain.Exceptions;
using System;
using System.Net;
using System.Web.Http;
using FluentValidation.Results;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Net.Http;
using Prova1.Infra.Csv;
using System.Text;
using System.IO;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Prova1.API.Models;
using AutoMapper;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;

namespace Prova1.API.Controllers.Common
{
    /// <summary>
    /// Controlador Base do Prova1.API
    /// 
    /// Essa classe é responsável por prover propriedades e métodos úteis nos demais controllers 
    /// que vão possuir essa classe como pai (herança).
    /// 
    /// Ela também herda da classe ApiController, com isso, suas implementações já se tornam controllers da API.
    /// </summary>
    public class ApiControllerBase : ApiController
    {

        #region Handlers
        /// <summary>
        /// Manuseia o callback. Valida se é necessário retornar erro ou o próprio TSuccess
        /// </summary> 
        /// <typeparam name="TSuccess"></typeparam>
        /// <param name="func">É a função que irá retornar o valor para o payload</param>
        /// <returns></returns>
        protected IHttpActionResult HandleCallback<TSuccess>(TSuccess data)
        {
            return Ok(data);
        }

        /// <summary>
        /// Manuseia um dado que foi resultado de uma query. Valida se é necessário retornar erro ou o próprio TSuccess
        /// </summary> 
        /// <typeparam name="TSuccess"></typeparam>
        /// <param name="func">É a função que irá retornar o valor para o payload</param>
        /// <returns></returns>
        protected IHttpActionResult HandleQuery<TSource, TResult>(TSource result)
        {
            if (Request.Headers.Accept.Contains(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv)))
                return ResponseMessage(HandleCSVFile(result));
            return Ok(Mapper.Map<TSource, TResult>(result));
        }

        /// <summary>
        /// Manuseia a query para aplicar as opções do odata.
        ///
        /// Esse método vai gerar o PageResult associando os dados (query) com as opções do odata (queryOptions) 
        /// após isso ele monta a resposta HTTP solicitada, conforme headers.
        /// 
        /// </summary>
        /// <typeparam name="TQueryOptions">Tipo do obj de origem (domínio)</typeparam>
        /// <typeparam name="TResult">Tipo de retorno </typeparam>
        /// <param name="query">IQueryable(TQueryOptions)</param>
        /// <param name="queryOptions">OdataQueryOptions(TQueryOptions)</param>
        /// <returns>IHttpActionResult(TResult) com o resultado da operação</returns>
        protected IHttpActionResult HandleQueryable<TSource, TResult>(IQueryable<TSource> query, ODataQueryOptions<TSource> queryOptions)
        {
            // Fazemos .ToList para obter os dados antes de converter (precisamos dos dados para conversão)
            // Após isso, é obtido um queryable dos resultdos convertendo para o tipo principal. Não há mais operação no banco.
            var odataQuery = queryOptions.ApplyTo(query).Cast<TSource>();
            var dataQuery = odataQuery.ToList().AsQueryable().ProjectTo<TResult>();
            if (Request.Headers.Accept.Contains(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv)))
                return ResponseMessage(HandleCSVFile(dataQuery));
            var pageResult = new PageResult<TResult>(dataQuery,
                                    Request.ODataProperties().NextLink,
                                    Request.ODataProperties().TotalCount);
            // Esse .ToList() é performado no ProjectTo e não mais no EF
            return Ok(pageResult);
        }

        /// <summary>
        /// Retorna IHttpStatusCode de erro + erros da validação.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationFailure">Erros de validação (ValidationFailure)</param>
        /// <returns>IHttpActionResult com os erros e status code padrão</returns>
        protected IHttpActionResult HandleValidationFailure<T>(IList<T> validationFailure)
            where T : ValidationFailure
        {
            return Content(HttpStatusCode.BadRequest, validationFailure);
        }

        #endregion

        #region  Handlers CSV
        /// <summary>
        /// Aplica o filtro (odata) a query, monta um HttpResultMessage com o arquivo CSV
        /// </summary>
        /// <typeparam name="TQueryOptions">Tipo do obj de origem (domínio)</typeparam>
        /// <typeparam name="TResult">Tipo de retorno objQuery</typeparam>
        /// <param name="query">IQueryable(TQueryOptions)</param>
        /// <param name="queryOptions">OdataQueryOptions</param>
        /// <returns>HttpResponseMessage</returns>
        /// 
       private HttpResponseMessage HandleCSVFile<TResult>(TResult data)
        {
            return HandleCSVFile(new List<TResult>() { data }.AsQueryable());
        }

        private HttpResponseMessage HandleCSVFile<TResult>(IQueryable<TResult> query)
        {
            var csv = query.ToCsv<TResult>(";");
            var bytes = Encoding.UTF8.GetBytes(csv);
            var stream = new MemoryStream(bytes, 0, bytes.Length, false, true);
            var result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(stream.GetBuffer()) };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypes.OctetStream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = string.Format("export{0}.csv", DateTime.UtcNow.ToString("yyyyMMddhhmmss"))
            };

            return result;
        }
        #endregion
    }
}