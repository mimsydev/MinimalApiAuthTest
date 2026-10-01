using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Security.Claims;

namespace MinimalApiAuthTest;

public class BasicAuthHandler
(
    IOptionsMonitor<MarqetaAuthenticationOptions> options,
    ILoggerFactory logger,
    UrlEncoder urlEncoder
) 
     : AuthenticationHandler<MarqetaAuthenticationOptions>(
         options, logger, urlEncoder
         )
{
    protected override async 
        Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        (string? headerValue, string? authValue)
            = (Request.Headers[Options.MarqetaHeaderName],
                Request.Headers["Authorization"]);
        
        if (string.IsNullOrEmpty(headerValue)
            || string.IsNullOrEmpty(authValue))
        {
            return AuthenticateResult.Fail("You do not rock.");
        }
        
        var claims = new List<Claim>
        {
            new("Rockage", "Very Yes")
        };
        var claimsIdentity = 
            new ClaimsIdentity(claims, Scheme.Name);
        var claimsPrincipal = 
            new ClaimsPrincipal(claimsIdentity);
        
        return AuthenticateResult.Success(
            new AuthenticationTicket(claimsPrincipal,
            Scheme.Name));
    }
}