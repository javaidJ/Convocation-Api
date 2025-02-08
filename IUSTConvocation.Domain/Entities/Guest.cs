using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;

namespace IUSTConvocation.Domain.Entities;

public class Guest : BaseModal, IBaseModal
{
	public string Name { get; set; } = string.Empty;

	public string Designation { get; set; } = string.Empty;//PM

    public Gender Gender { get; set; }

    public string Email { get; set; } = string.Empty;

	public string ContactNo { get; set; } = string.Empty;

    //public ParticipantRole ParticipantRole { get; set; }

    public string GuestArrivedFrom { get; set; } = string.Empty;//PM Office

    public bool IsOutSider { get; set; } = false;
    public bool IsDeleted { get; set; }


    public string? Description { get; set; }

}
