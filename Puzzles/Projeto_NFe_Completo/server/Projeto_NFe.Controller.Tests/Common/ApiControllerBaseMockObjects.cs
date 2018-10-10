using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Projeto_NFe.API.Controladores.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Projeto_NFe.Controller.Tests.Common
{
    public class ApiControllerBaseFake : ApiControllerBase
    {
        public IHttpActionResult HandleCallback<TSuccess>(Func<TSuccess> func)
        {
            return base.HandleCallback(func);
        }

        public IHttpActionResult HandleQuery<OriginType, TResult>(IQueryable<OriginType> query, ODataQueryOptions<OriginType> queryOptions)
        {
            return base.HandleQuery<OriginType, TResult>(query, queryOptions);
        }


        public PageResult<RetType> HandlePageResult<OriginType, RetType>(IQueryable<OriginType> query, ODataQueryOptions<OriginType> queryOptions)
        {
            return base.HandlePageResult<OriginType, RetType>(query, queryOptions);
        }

        public IHttpActionResult HandleValidationFailure<T>(IList<T> validationFailure) where T : ValidationFailure
        {
            return base.HandleValidationFailure<T>(validationFailure);
        }
    }

    /// <summary>
    /// Dummy usado para preencher valores: um tipo vazio
    /// </summary>
    public class ApiControllerBaseDummy
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// Dummy usado para conversões de mapeamento
    /// </summary>
    public class ApiControllerBaseDummyQuery
    {
        public int Id { get; set; }
    }
}