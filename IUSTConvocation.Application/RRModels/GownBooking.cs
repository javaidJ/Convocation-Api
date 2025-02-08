using IUSTConvocation.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IUSTConvocation.Application.RRModels;

public class GownBookingRequest
{
    public Guid GownId { get; set; }


    public Guid EntityId { get; set; }

    [Required(ErrorMessage ="Gown Status is required")]
    public GownStatus GownStatus { get; set; }


  //  public bool IsAvailable { get; set; }

}


public class GownBookingResponse : GownBookingRequest
{
    public string Color { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public int Charges { get; set; }

    public GownSize Size { get; set; }

    public DateTimeOffset PaymentDate { get; set; }

    public Guid FileId { get; set; }

    public string FilePath { get; set; } = string.Empty;

    public GownStatus GownStatus { get; set; }

    public Guid UserId { get; set; }

    public string Receipt { get; set; } = string.Empty;

    public string Currency { get; set; }=string.Empty;

    public AppOrderStatus OrderStatus { get; set; }

    public string TransactionId { get; set; } = string.Empty;
    public double Amount { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public AppPaymentStatus AppPaymentStatus { get; set; }   
}


public class StudentBookingGownResponse : GownBookingResponse
{
    public string ConvocationName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTimeOffset ConvocationDate { get; set; }
}


public class StudentGownBookingsResponse
{
    
    public string Color { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public int Charges { get; set; }

    public GownSize Size { get; set; }

    public DateTimeOffset PaymentDate { get; set; }

    public Guid FileId { get; set; }

    public string FilePath { get; set; } = string.Empty;

    public GownStatus GownStatus { get; set; }

    public Guid UserId { get; set; }

    public string Receipt { get; set; } = string.Empty;

    public string Currency { get; set; } = string.Empty;

    public AppOrderStatus OrderStatus { get; set; }

    public string TransactionId { get; set; } = string.Empty;
    public double Amount { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public AppPaymentStatus AppPaymentStatus { get; set; }
    public Guid ConvocationId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string ContactNo { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Batch { get; set; } 
    public Course Course { get; set; } 
    public Position Position { get; set; }
    public string RegNumber { get; set; } = string.Empty;
    public string Parentage { get; set; } = string.Empty;
}

