using System.Web.Http;

namespace MF6.API {

    public class WebApiApplication : System.Web.HttpApplication {

        protected void Application_Start() {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}