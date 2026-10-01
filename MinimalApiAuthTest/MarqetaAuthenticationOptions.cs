using Microsoft.AspNetCore.Authentication;

namespace MinimalApiAuthTest;

public class MarqetaAuthenticationOptions 
    : AuthenticationSchemeOptions
{
    public const string DefaultScheme = "Marqeta";
    public string MarqetaHeaderName => "X-Marqeta-Signature";
}