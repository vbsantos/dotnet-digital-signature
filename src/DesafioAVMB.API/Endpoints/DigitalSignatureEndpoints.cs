using System.Security.Claims;

namespace DesafioAVMB.API.Endpoints;

public static class DigitalSignatureEndpoints
{
    /// <summary>
    /// Adds the endpoints for the digital signature.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder AddDigitalSignatureEndpoints(this IEndpointRouteBuilder app)
    {
        // FIXME remover
        // app.MapGet("/userName", (ClaimsPrincipal user) => $"Desafio AVMB: {user.Identity!.Name}.")
        //     .RequireAuthorization()
        //     .WithTags("Other");

        app.MapPost("/repository", (ClaimsPrincipal user) => "Repository created.")
            .RequireAuthorization().WithTags("Repository");
        app.MapGet("/repository/{repositoryId}", (Guid repositoryId, ClaimsPrincipal user) => "Repository created.")
            .RequireAuthorization().WithTags("Repository");

        app.MapPost("/repository/{repositoryId}/envelope", (Guid repositoryId, ClaimsPrincipal user) => "Envelope created.")
            .RequireAuthorization().WithTags("Envelope");
        app.MapGet("/repository/{repositoryId}/envelope/{envelopeId}", (Guid repositoryId, Guid envelopeId, ClaimsPrincipal user) => "Envelope created.")
            .RequireAuthorization().WithTags("Envelope");

        app.MapPost("/repository/{repositoryId}/envelope/{envelopeId}/signatory", (Guid repositoryId, Guid envelopeId, ClaimsPrincipal user) => "Envelope Signatory added.")
            .RequireAuthorization().WithTags("Signature");
        app.MapGet("/repository/{repositoryId}/envelope/{envelopeId}/signatory/{signatoryId}", (Guid repositoryId, Guid envelopeId, Guid signatoryId, ClaimsPrincipal user) => "Envelope Signatory added.")
            .RequireAuthorization().WithTags("Signature");

        app.MapPost("/repository/{repositoryId}/envelope/{envelopeId}/send", (Guid repositoryId, Guid envelopeId, ClaimsPrincipal user) => "Envelope Signatory added.")
            .RequireAuthorization().WithTags("Envelope");

        app.MapGet("/repository/{repositoryId}/envelope/{envelopeId}/file", (Guid repositoryId, Guid envelopeId, ClaimsPrincipal user) => "Get Envelope.")
            .RequireAuthorization().WithTags("Download");

        return app;
    }
}
