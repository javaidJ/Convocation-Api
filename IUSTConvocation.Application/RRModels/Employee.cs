using IUSTConvocation.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IUSTConvocation.Application.RRModels;

public class EmployeeRequest 
{
    public Guid Id { get; set; }

    [Required(ErrorMessage ="Name is required")]
    public string Name  { get; set; } =  string.Empty;

    [Required(ErrorMessage ="Email is required")]
    [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please Enter Valid Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Contact Number is required")]
    public string ContactNo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Gender  is required")]
    public Gender Gender { get; set; }

    public string? EmpCode  { get; set; } = string.Empty;

    // public JobRole? JobRole { get; set; }

    [Required(ErrorMessage = "Designation Number is required")]
    public Designation Designation  { get; set; }

    public Guid? DepartemntId { get; set; }

    [Required(ErrorMessage = "File is required")]
    public IFormFile File { get; set; } = null!;
}

public class EmployeeResponse : EmployeeRequest
{
    public string FilePath { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }

}

