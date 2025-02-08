using IUSTConvocation.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;


namespace IUSTConvocation.Domain.Entities;

public class Pass: BaseModal, IBaseModal
{

    public string PassNumber { get; set; } = string.Empty;


    public Guid IUSTConvocationId { get; set; }


    public Guid EntityId { get; set; }

    public string? VehicleNo { get; set; } = string.Empty;  


    [ForeignKey(nameof(IUSTConvocationId))]
    public Convocation IUSTConvocation { get; set; } = null!;
}
