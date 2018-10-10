using Projeto_NFe.API.Excecoes;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Projeto_NFe.API.Extensoes
{
    public static class ExceptionHandlingExtensions
    {
        public static HttpResponseMessage HandleExecutedContextException(this HttpActionExecutedContext context)
        {
            return context.Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionPayload.Novo(context.Exception));
        }
    }
}