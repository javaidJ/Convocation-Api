using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Application.RRModels
{
    public class ContactRequest
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; } = null!;


        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; } = null!;
    }

    public class ContactResponse:ContactRequest
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
