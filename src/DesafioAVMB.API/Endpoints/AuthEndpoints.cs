using Microsoft.AspNetCore.Identity;

namespace DesafioAVMB.API.Endpoints;

public static class AuthEndpoints
{
    /// <summary>
    /// Adds the endpoints for the account management.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder AddAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGroup("account")
            .WithDescription("Only the basic endpoints (/login, /register) work for now.")
            .MapIdentityApi<IdentityUser>()
            .WithSummary("Microsoft Identity Endpoint")
            .WithTags("Account");

        return app;
    }
}
