using IUSTConvocation.Domain.Enums;

namespace IUSTConvocation.Application.RRModels;

public class VenueRequest
{
    public string Name { get; set; } = string.Empty;

    public int TotalSeats { get; set; }

}


public class VenueResponse : VenueRequest
{
    public Guid Id { get; set; }
}

public class VenueUpdateRequest : VenueRequest
{
    public Guid Id { get; set; }
}