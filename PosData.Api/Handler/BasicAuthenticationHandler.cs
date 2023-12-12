using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
using PosData.Api.Models;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace PosData.Api.Handler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!this.Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            User user = null;

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(this.Request.Headers["Authorization"]);
                user = this.DoAuthentication(authHeader.Parameter);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (user == null)
            {
                return AuthenticateResult.Fail("Invalid Username or Password");
            }
            var claims = new[] { new Claim(ClaimTypes.NameIdentifier, user.UserName), new Claim(ClaimTypes.Name, user.UserName), };

            var identity = new ClaimsIdentity(claims, this.Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, this.Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }


        private User DoAuthentication(string authHeader)
        {
            byte[] basicAuthHeader = Convert.FromBase64String(authHeader);
            var token = Encoding.UTF8.GetString(basicAuthHeader);


            var userWhiteLists = "username:password"?
                .Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries)?.ToList()
                ?? new List<string>();

            if (userWhiteLists.Contains(token))
            {
                string[] credentials = token.Split(new[] { ':' }, 2);

                return new User()
                {
                    UserName = credentials[0]
                };
            }

            return null;
        }
    }
}
