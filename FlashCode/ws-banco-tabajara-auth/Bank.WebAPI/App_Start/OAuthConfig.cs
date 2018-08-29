using Bank.Application.Features.Authentication;
using Bank.WebAPI.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Bank.WebAPI.App_Start
{
    [ExcludeFromCodeCoverage]
    public static class OAuthConfig
    {
        public static void ConfigOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new ProviderAccessToken()
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}