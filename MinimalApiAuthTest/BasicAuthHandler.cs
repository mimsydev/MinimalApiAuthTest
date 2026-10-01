using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

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
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        return  AuthenticateResult.Fail("You suck");
    }
}