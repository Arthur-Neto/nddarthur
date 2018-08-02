using MF6.API.Extensions;
using System.Web.Http.Filters;

namespace MF6.API.Filters {

    public class ExceptionHandlerAttribute : ExceptionFilterAttribute {

        /// <summary>
        /// Método invocado quando ocorre uma exceção no controller
        /// </summary>
        /// <param name="context">É o contexto atual da requisição</param>
        public override void OnException(HttpActionExecutedContext context) {
            context.Response = context.HandleExecutedContextException();
        }
    }
}