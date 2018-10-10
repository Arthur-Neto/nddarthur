using Prova1.API.Exceptions;
using Prova1.Domain.Exceptions;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Prova1.API.Extensions
{
    public static class ExceptionHandlingExtensions
    {
        /// <summary>
        /// Extension Method do HttpActionExecutedContext para manipular o context quando há uma exceção 
        /// e retornar um ExceptionPayload customizado, informando ao client o que houve de errado.
        /// 
        /// </summary>
        /// <param name="context">É o contexto atual da requisição</param>
        /// <returns>HttpResponseMessage contendo a exceção</returns>
        public static HttpResponseMessage HandleExecutedContextException(this HttpActionExecutedContext context)
        {
            // Retorna a resposta para o cliente com o erro 500 ou 400 e o ExceptionPayload (código de erro de negócio e mensagem)
            var exceptionPayload = ExceptionPayload.New(context.Exception);
            return context.Exception is BusinessException ?
                context.Request.CreateResponse(HttpStatusCode.BadRequest, exceptionPayload) :
                context.Request.CreateResponse(HttpStatusCode.InternalServerError, exceptionPayload);
        }
    }
}