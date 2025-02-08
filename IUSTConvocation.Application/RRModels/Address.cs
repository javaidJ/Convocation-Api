using IUSTConvocation.Domain.Enums;

namespace IUSTConvocation.Application.RRModels;
public class AddressRequest
{
    public string Country { get; set; } = string.Empty;


    public string State { get; set; }=string.Empty;


    public string City { get; set; } = string.Empty;


    public int PostalCode { get; set; }


    public string AddressLine { get; set; } = string.Empty;


    public Module Module { get; set; }


    public Guid? EntityId { get; set; }
}

public class AddressResponse : AddressRequest
{
    public Guid AddressId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset CreatedOn { get; set; }
}


public class AddressUpdateRequest : AddressRequest
{
    public Guid Id { get; set; }
}