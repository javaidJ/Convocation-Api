using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;

namespace IUSTConvocation.Domain.Entities;

public class AppOrder : BaseModal, IBaseModal
{
    public string OrderId { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public Guid GownBookingId { get; set; }

    public string Receipt { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }


    public int CreatedAt { get; set; }

    public string Currency { get; set; } = "INR";

    public AppOrderStatus OrderStatus { get; set; }


    public ICollection<AppPayment> Payments { get; set; } = null!;
}
