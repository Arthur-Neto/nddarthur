using Arthur.MF7.WebAPI.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Arthur.MF7.WebAPI.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ExceptionHandlingExtensions
    {
        public static HttpResponseMessage HandleExecutedContextException(this HttpActionExecutedContext context)
        {
            return context.Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionPayload.New(context.Exception));
        }
    }
}