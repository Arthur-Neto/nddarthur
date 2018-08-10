using Bank.WebAPI.Extensions;
using System.Web.Http.Filters;

namespace Bank.WebAPI.Filters
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.HandleExecutedContextException();
        }
    }
}