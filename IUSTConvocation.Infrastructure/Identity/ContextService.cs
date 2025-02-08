using IUSTConvocation.Application.Abstractions.Identity;
using IUSTConvocation.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace KashmirService.Infrastructure.Identity;

internal sealed class ContextService : IContextService
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private const string UserRole = nameof(UserRole);

    public ContextService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public Guid GetUserId()
    {
        var userId = httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == AppClaimTypes.UserId)?.Value;
        
        if(userId == null)
            return Guid.Empty;

        Guid.TryParse(userId, out Guid result);
        return result;
    }

    public string? GetUserRole()
    {
        return httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == AppClaimTypes.UserRole)?.Value;
    }

    public string? GetUserName()
    {
        return httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == AppClaimTypes.UserName)?.Value;
    }

    //public string? GetName()
    //{
    //    return httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == AppClaimTypes.Name)?.Value;

    //}

    public string? GetEmail()
    {
        return httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == AppClaimTypes.Email)?.Value;
    }


    public string HttpContextCurrentURL()
    {
        var path = httpContextAccessor?.HttpContext?.Request.Path;
        return $" {httpContextAccessor?.HttpContext?.Request.Scheme}://{httpContextAccessor?.HttpContext?.Request.Host}{httpContextAccessor?.HttpContext?.Request.PathBase}";
    }

    public string HttpContextClientURL()
    {
        var clientRequest = httpContextAccessor?.HttpContext?.Request.Headers["Referer"];
        return $"{clientRequest}";
    }
}