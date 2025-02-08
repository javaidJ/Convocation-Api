
using IUSTConvocation.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace IUSTConvocation.Application.RRModels;
public class ConvocationRequest
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    public Guid VenueId { get; set; }

    [Required(ErrorMessage = "Convocation Date is required")]
    public DateTimeOffset ConvocationDate { get; set; }

    public TimeOnly End { get; set; }

    public string? Description { get; set; } = string.Empty;

}


public class ConvocationResponse : ConvocationRequest
{
    public Guid Id { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

}

public class ConvocationWithVenueResponse {
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTimeOffset ConvocationDate { get; set; }

    public TimeOnly End { get; set; }

    public string? Description { get; set; }

    public Guid VenueId { get; set; }

    public string Venue { get; set; } = string.Empty;

    public int TotalSeats { get; set; }

}

public class StudentConvocationDetailsResponse : ConvocationWithVenueResponse
{
    public SeatSection SeatSection { get; set; }

    public int Row { get; set; }

    public string SeatNo { get; set; } = string.Empty;

    public int DaysLeft { get; set; }
}

public class ConvocationCompact : ConvocationWithVenueResponse
{
    public int TotalGuests { get; set; }
    public int TotalStudents { get; set; }
    public int TotalMembers { get; set; }
    public int TotalParticipants { get; set; }
}

public class MemberConvocationResponse : ConvocationWithVenueResponse
{
  
    public Guid MemberId { get; set; }

    public JobRole  JobRole{ get; set; }


}
public class ConvocationUpdateRequest : ConvocationRequest
{
    public Guid Id { get; set; }
}