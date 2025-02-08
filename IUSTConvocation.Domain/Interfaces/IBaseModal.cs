namespace IUSTConvocation.Domain.Interfaces;

public interface IBaseModal
{

    public Guid Id { get; set; }


    public Guid CreatedBy { get; set; }


    public Guid UpdatedBy { get; set; }


    public DateTimeOffset CreatedOn { get; set; }


    public DateTimeOffset UpdatedOn { get; set; }

}
