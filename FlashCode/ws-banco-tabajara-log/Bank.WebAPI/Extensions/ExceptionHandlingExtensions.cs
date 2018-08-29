using Bank.WebAPI.Exceptions;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Bank.WebAPI.Extensions
{
    public static class ExceptionHandlingExtensions
    {
        public static HttpResponseMessage HandleExecutedContextException(this HttpActionExecutedContext context)
        {
            return context.Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionPayload.New(context.Exception));
        }
    }
}