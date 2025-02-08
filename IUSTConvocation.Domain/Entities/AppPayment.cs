using System.ComponentModel.DataAnnotations.Schema;
using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;

namespace IUSTConvocation.Domain.Entities;

public class AppPayment : BaseModal, IBaseModal
{
    public string TransactionId { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "INR";


    public PaymentMethod PaymentMethod { get; set; }

    public AppPaymentStatus AppPaymentStatus { get; set; }

    public string RpOrderId { get; set; } = string.Empty;


    public Guid OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public AppOrder Order { get; set; } = null!;

}
