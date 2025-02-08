using IUSTConvocation.Domain.Enums;

namespace IUSTConvocation.Application.RRModels;

public class SeatRequest
{
    public Guid VenueId { get; set; }

    public SeatSection SeatSection { get; set; }

    public int Row { get; set; }

    public string SeatNumber { get; set; } = null!;
}


public class SeatResponse : SeatRequest
{
    public Guid Id { get; set; }
}

public class SeatUpdateRequest : SeatRequest
{
    public Guid Id { get; set; }
}