using Microsoft.Owin;
using Owin;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

[assembly: OwinStartup(typeof(MF6.API.Startup))]

namespace MF6.API {

    [ExcludeFromCodeCoverage]
    public class Startup {

        public void Configuration(IAppBuilder app) {
            HttpConfiguration config = new HttpConfiguration();
            app.UseWebApi(config);
        }
    }
}