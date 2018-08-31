using Arthur.MF7.WebAPI.Extensions;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http.Filters;

namespace Arthur.MF7.WebAPI.Filters
{
    [ExcludeFromCodeCoverage]
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.HandleExecutedContextException();
        }
    }
}