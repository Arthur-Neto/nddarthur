using MF6.API.Exceptions;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace MF6.API.Extensions {

    public static class ExtensionHandlingExtensions {

        public static HttpResponseMessage HandleExecutedContextException(this HttpActionExecutedContext context) {
            return context.Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionPayload.New(context.Exception));
        }
    }
}