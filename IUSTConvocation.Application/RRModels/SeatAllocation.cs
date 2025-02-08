using IUSTConvocation.Domain.Enums;

namespace IUSTConvocation.Application.RRModels;

public class SeatAllocationRequest
{
    public Guid? EntityId { get; set; }

    public Guid SeatId { get; set; }

    public Guid ConvocationId { get; set; }
}

public class SeatAllocationResponse : SeatAllocationRequest
{
    public Guid Id { get; set; }

   

}

public class AllocatedSeatsResponse : SeatAllocationRequest
{

    public Guid Id { get; set; }

    public SeatSection SeatSection { get; set; }

    public string SeatNumber { get; set; } = null!;

    public int Row { get; set; }

    public string Name { get; set; } = string.Empty;

    public string ContactNo { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Gender Gender { get; set; }

    public int ParticipantRole { get; set; }

    public Module Module { get; set; }
}

public class SeatAllocationUpdateRequest : SeatAllocationRequest
{
    public Guid Id { get; set; }
}
