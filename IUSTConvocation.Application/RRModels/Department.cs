
using System.ComponentModel.DataAnnotations;

namespace IUSTConvocation.Application.RRModels;

public class DepartmentRequest
{
    [Required(ErrorMessage ="Department is required")]
    public string DepartmentName { get; set; } = string.Empty;
}


public class DepartmentResponse : DepartmentRequest
{
    public Guid Id { get; set; }

    public bool IsDeleted { get; set; }
}

public class DepartmentUpdateRequest : DepartmentRequest
{
    public Guid Id { get; set; }
}