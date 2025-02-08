using IUSTConvocation.Domain.Interfaces;

namespace IUSTConvocation.Domain.Entities;

public class BaseModal : IBaseModal
{

    public Guid Id { get; set; } = Guid.NewGuid();


    public Guid CreatedBy { get; set; }


    public Guid UpdatedBy { get; set; }


    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;


    public DateTimeOffset UpdatedOn { get; set; } = DateTimeOffset.Now;

}
