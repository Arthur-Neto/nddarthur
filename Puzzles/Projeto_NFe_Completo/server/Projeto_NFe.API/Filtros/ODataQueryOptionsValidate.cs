using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.AspNet.OData.Query;

namespace Projeto_NFe.API.Filtros
{
    [ExcludeFromCodeCoverage]
    public class ODataQueryOptionsValidateAttribute : ActionFilterAttribute
    {

        private ODataValidationSettings oDataValidationSettings;

        public ODataQueryOptionsValidateAttribute(AllowedQueryOptions allowedQueryOptions = AllowedQueryOptions.All ^ AllowedQueryOptions.Expand)
        {
            oDataValidationSettings = new ODataValidationSettings() { AllowedQueryOptions = allowedQueryOptions };
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.Any(a => a.Value != null && a.Value.GetType().Name.Contains(typeof(ODataQueryOptions).Name)))
            {
                var odataQueryOptions = (ODataQueryOptions)actionContext.ActionArguments.Where(a => a.Value != null && a.Value.GetType().Name.Contains(typeof(ODataQueryOptions).Name)).FirstOrDefault().Value;
                odataQueryOptions.Validate(oDataValidationSettings);
            }

            base.OnActionExecuting(actionContext);
        }
    }
}