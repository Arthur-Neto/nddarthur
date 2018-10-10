using Projeto_NFe.API.Extensoes;
using System.Web.Http.Filters;

namespace Projeto_NFe.API.Filtros
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.HandleExecutedContextException();
        }
    }
}