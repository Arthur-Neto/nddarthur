using Bank.Application.Features.Authentication;
using Bank.Domain.Features.Users;
using Bank.WebAPI.Ioc;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bank.WebAPI.Providers
{
    [ExcludeFromCodeCoverage]
    public class ProviderAccessToken : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var user = default(User);

            try
            {
                var authService = SimpleInjectorContainer.Container.GetInstance<AuthenticationService>();

                user = authService.Login(context.UserName, context.Password);
            }
            catch (Exception)
            {
                context.SetError("invalid_grant", "User not found.");
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim("UserId", user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            var ticket = new AuthenticationTicket(identity, null);
            context.Validated(ticket);

            return Task.FromResult<object>(null);
        }
    }
}