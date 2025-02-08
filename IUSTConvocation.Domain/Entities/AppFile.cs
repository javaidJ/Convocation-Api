using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;

namespace IUSTConvocation.Domain.Entities;

public class AppFile : BaseModal, IBaseModal
{

    public Module Module { get; set; }


    public string FilePath { get; set; } = string.Empty;


    public Guid EntityId { get; set; }

}
