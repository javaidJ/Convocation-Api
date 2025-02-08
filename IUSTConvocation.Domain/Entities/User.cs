using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;

namespace IUSTConvocation.Domain.Entities;

public class User : BaseModal, IBaseModal
{

    public string Username { get; set; } = string.Empty;


    public string Password { get; set; } = string.Empty;


    public string Salt { get; set; } = string.Empty;


    public string Email { get; set; } = string.Empty;


    public string ContactNo { get; set; } = string.Empty;


    public string ResetCode { get; set; } = string.Empty;


    public Gender Gender { get; set; }


    public UserRole UserRole { get; set; } = UserRole.Admin;


    public UserStatus UserStatus { get; set; } = UserStatus.Active;


    public bool IsEmailVerified { get; set; }

    public string ConfirmationCode { get; set; } = string.Empty;


    #region Navigation props
    public Student Student { get; set; } = null!;
	public Employee Employee { get; set; }=null!;   
	#endregion

}