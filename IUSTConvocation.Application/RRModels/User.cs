#region using
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;

#endregion 


namespace IUSTConvocation.Application.RRModels;
public class UserSignUpRequest
{
    [Required(ErrorMessage ="Name is required")]
    public string Name { get; set; } = string.Empty;



    [Required(ErrorMessage = "Email is required")]
    [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please Enter Valid Email")]
    public string Email { get; set; } = string.Empty;


    [Required(ErrorMessage = "Contact No. is reuired")]
    public string ContactNo { get; set; } = string.Empty;


    [Required(ErrorMessage = "Select Role")]
    public UserRole UserRole { get; set; }


    [Required(ErrorMessage = "Department  is reuired")]
    public Guid? DepartemntId { get; set; }


    [Required(ErrorMessage = "Designation is reuired")]
    public Designation? Designation { get; set; }
}


public class StudentSignupRequest
{

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;


    [Required(ErrorMessage = "Parentage is required")]
    public string Parentage { get; set; } = string.Empty;


    [Required(ErrorMessage = "Registration No. is required")]
    public string RegNumber { get; set; } = null!;



    [Required(ErrorMessage = "Department is required")]
    public Guid? DepartemntId { get; set; }

    [Required(ErrorMessage = "Course is required")]
    public Course Course { get; set; }



    [Required(ErrorMessage = "Batch is required")]
    public int Batch { get; set; }


    [Required(ErrorMessage = "Percentage is required")]
    public double Percentage { get; set; }

    [Required(ErrorMessage = "Position is required")]
    public Position Position { get; set; }


    [Required(ErrorMessage = "UserName is required")]
    public string UserName { get; set; } = string.Empty;


    [Required(ErrorMessage ="Email is reuired")]
    [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Invalid email"), MinLength(6)]
    public string Email { get; set; } = string.Empty;


    [Required(ErrorMessage = "Contact No. is required")]
    public string ContactNo { get; set; } = string.Empty;


    [Required(ErrorMessage = "Gender is required")]
    public Gender Gender { get; set; }


    [Required(ErrorMessage = "Password is required")] 
    
    public string Password { get; set; } = string.Empty;


    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare(nameof(Password), ErrorMessage = "Password & Confirm do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}



public class SignUpResponse
{
    public Guid Id { get; set; }


    public string UserName { get; set; } = string.Empty;


    public string Email { get; set; } = string.Empty;


    public string ContactNo { get; set; } = string.Empty;


    public Gender Gender { get; set; }


    public UserRole UserRole { get; set; } = UserRole.Student;


    public bool IsEmailVerified { get; set; }

}


public class LoginRequest
{

    [Required(ErrorMessage = "Please Enter Your Valid UserName")]
    public string UserName { get; set; } = string.Empty;


    [Required(ErrorMessage = "Please Enter Password"), DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

}


public class LoginResponse
{
    public string UserName { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public UserRole UserRole { get; set; }

    public bool IsEmailVerified { get;  set; }
}


public class ChangePasswordRequest
{

    [Required(ErrorMessage = "Enter Old Password")]
    public string OldPassword { get; set; } = string.Empty;


    [Required(ErrorMessage = "Please Enter Password"), DataType(DataType.Password)]
    public string NewPassword { get; set; } = string.Empty;


    [Compare(nameof(NewPassword))]
    public string ConfirmPassword { get; set; } = string.Empty;

}



public class ForgotPasswordRequest
{

    public string Email { get; set; } = string.Empty;

}


public class VerifyEmailRequest
{

    public string ConfirmationCode { get; set; } = string.Empty;

}



public class ResetPasswordRequest
{

    [Required]
    public string ResetCode { get; set; } = string.Empty;


    [Required]
    public string NewPassword { get; set; } = string.Empty;


    [Required]
    [Compare(nameof(NewPassword), ErrorMessage = "Password / Confirm password do not match.")]
    public string ConfrimPassword { get; set; } = string.Empty;

}