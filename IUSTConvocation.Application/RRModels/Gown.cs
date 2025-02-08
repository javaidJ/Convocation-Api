using IUSTConvocation.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IUSTConvocation.Application.RRModels;

public class GownRequest
{
    [Required(ErrorMessage = "Color is required")]
    public string Color { get; set; } = null!;

    [Required(ErrorMessage = "Quantity is required")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Size is required")]
    public GownSize Size { get; set; }

    [Required(ErrorMessage = "Charges is required")]
    public int Charges { get; set; }

    [Required(ErrorMessage ="Files is required")]
    public IFormFileCollection Files { get; set; }
}


public class AppFileRequest
{
    public Guid EntityId { get; set; }

    [Required(ErrorMessage = "Files is required")]
    public IFormFile File { get; set; }
}

public class AppFileResponse
{
    public Guid Id { get; set; }

    public string FilePath { get; set; } = null!;

    public Module Module { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

}

public class GownResponse : GownRequest
{

    public Guid Id { get; set; }
   

    public string FilePath { get; set; } = string.Empty;

    public DateTimeOffset CreatedOn { get; set; }

    public Guid FileId { get; set; }
}

public class GownUpdateRequest
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Color is required")]
    public string Color { get; set; } = null!;

    [Required(ErrorMessage = "Quantity is required")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Size is required")]
    public GownSize Size { get; set; }

    [Required(ErrorMessage = "Charges  are required")]
    public int Charges { get; set; }
}