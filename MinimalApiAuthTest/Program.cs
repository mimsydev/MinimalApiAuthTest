using Microsoft.AspNetCore.Authentication;
using MinimalApiAuthTest;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication()
    .AddScheme<MarqetaAuthenticationOptions, BasicAuthHandler>(
        MarqetaAuthenticationOptions.DefaultScheme,
        options => { }
        );

builder.Services.AddAuthorizationBuilder()
    .AddFallbackPolicy(
    "Fallback", policy =>
    {
        policy.RequireAuthenticatedUser();
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/health", () => "Healthy")
    .WithName("Healthy").AllowAnonymous();

app.MapGet("/hidden", () => "Hidden")
    .WithName("Hidden");

app.Run();
