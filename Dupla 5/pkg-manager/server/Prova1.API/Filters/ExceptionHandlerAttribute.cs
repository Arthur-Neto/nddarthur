using Prova1.API.Extensions;
using System.Web.Http.Filters;

namespace Prova1.API.Filters
{
    /// <summary>
    /// Classe que será o atributo nos controllers [ExceptionHandler] que captura as exceções
    /// e utiliza o extension method HandleExecutedContextException
    /// para responder ao client com o código e a mensagem adequados.
    /// 
    /// Precisamos fazer isso pois temos exceções de negócio, 
    /// que são definidas em Prova1.Domain 
    /// e precisa ser montado uma resposta http adequada para o client.
    /// 
    /// Para evitar a repetição de [ExceptionHandler] nos controllers,
    /// foi adicionado globalmente nas configurações em WebApiConfig.Register().
    /// 
    /// </summary>
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Método invocado quando ocorre uma exceção no controller
        /// </summary>
        /// <param name="context">É o contexto atual da requisição</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.HandleExecutedContextException();
        }
    }
}