using IUSTConvocation.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IUSTConvocation.Application.RRModels;

public class StudentRequest
{
    public Guid Id { get; set; }


    [Required(ErrorMessage = "RegNumber is required")]
    public string RegNumber { get; set; } = string.Empty;

    [Required(ErrorMessage ="Name is required")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage ="Email is required")]
    [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please Enter Valid Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage ="Contact Number is required")]
    public string ContactNo { get; set; } = string.Empty;

    [Required(ErrorMessage ="Gender is required")]
    public Gender Gender { get; set; }

    [Required(ErrorMessage ="Parentage is required")]
    public string Parentage { get; set; } = string.Empty;

    public Guid? DepartemntId { get; set; }

    [Required(ErrorMessage ="Course is required")]
    public Course Course { get; set; }

    [Required(ErrorMessage ="Batch is required")]
    public int Batch { get; set; }

    [Required(ErrorMessage ="Percentage is required")]
    public double Percentage { get; set; }

    [Required(ErrorMessage ="Position is required")]
    public Position Position { get; set; }


    [Required(ErrorMessage ="File is required")]
    public IFormFile File { get; set; } = null!;
}


public class StudentResponse : StudentRequest
{
    public  string FilePath { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }
}

public class StudentUpdateRequest : StudentRequest
{
  
}

public class RegistrationStatusRequest
{

    public Guid StudentId { get; set; }

    public RegistrationStatus RegistrationStatus { get; set; }

}