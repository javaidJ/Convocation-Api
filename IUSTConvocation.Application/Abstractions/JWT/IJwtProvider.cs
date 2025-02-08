using IUSTConvocation.Domain.Entities;

namespace IUSTConvocation.Application.Abstractions.JWT;

public interface IJwtProvider
{
    public string GenerateToken(User user);
}
