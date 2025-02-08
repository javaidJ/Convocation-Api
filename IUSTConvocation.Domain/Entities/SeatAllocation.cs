using IUSTConvocation.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUSTConvocation.Domain.Entities;

public class SeatAllocation : BaseModal, IBaseModal
{
    public Guid? EntityId { get; set; }

    public Guid SeatId { get; set; }

    public Guid ConvocationId { get; set; }


    [ForeignKey(nameof(SeatId))]
    public Seat Seat { get; set; } = null!;


    [ForeignKey(nameof(ConvocationId))]
    public Convocation  Convocation { get; set; } = null!;

}
