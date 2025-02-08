using IUSTConvocation.Domain.Interfaces;

namespace IUSTConvocation.Domain.Entities;

public sealed class Contact : BaseModal, IBaseModal
{
    public string Name { get; set; } = null!;


    public string Email { get; set; } = null!;


    public string PhoneNumber { get; set; } = null!;


    public string Message { get; set; } = null!;
}
