using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUSTConvocation.Domain.Entities;

public class Seat : BaseModal, IBaseModal
{
    public Guid VenueId { get; set; }

    public SeatSection SeatSection { get; set; }

    public int Row { get; set;}

    public string SeatNumber { get; set; } = null!;


    [ForeignKey(nameof(VenueId))]
    public Venue Venue { get; set; } = null!;
}
