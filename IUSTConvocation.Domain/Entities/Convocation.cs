using IUSTConvocation.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUSTConvocation.Domain.Entities;
public class Convocation : BaseModal, IBaseModal
{
    public string Name { get; set; } = string.Empty;

    public Guid VenueId { get; set; } 

    public DateTimeOffset ConvocationDate { get; set; }

    public TimeOnly End { get; set; }   

    public bool IsDeleted { get; set; }

    public string? Description { get; set; } = string.Empty;

    public ICollection<Member> Members { get; set; } = null!;

    public ICollection<Registration> Registrations { get; set; } = null!;


    [ForeignKey(nameof(VenueId))]
    public Venue Venue { get; set; } = null!;


    public ICollection<GownBooking> GownBookings{ get; set; } = null!;

}
