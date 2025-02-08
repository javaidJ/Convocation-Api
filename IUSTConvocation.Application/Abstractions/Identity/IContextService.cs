namespace IUSTConvocation.Application.Abstractions.Identity;

public interface IContextService
{
    Guid GetUserId();

    string? GetUserName();

  //  string? GetName();

    string? GetEmail();

    string? GetUserRole();

    string HttpContextClientURL();

    string HttpContextCurrentURL();
}
