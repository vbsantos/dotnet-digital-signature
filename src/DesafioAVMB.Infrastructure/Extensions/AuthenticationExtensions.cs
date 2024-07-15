using System.Security.Claims;

namespace DesafioAVMB.Infrastructure.Extensions;

public static class AuthenticationExtensions
{
    public static Guid GetId(this ClaimsPrincipal principal)
    {
        var userId = principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
        var userIdParsed = Guid.Parse(userId);
        return userIdParsed;
    }
}
