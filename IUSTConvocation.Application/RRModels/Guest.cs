using IUSTConvocation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Application.RRModels
{
    public class GuestRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        public string? Designation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Number is required")]
        public string ContactNo { get; set; } = string.Empty;

        //[Required(ErrorMessage = "ParticipantRole is required")]
        //public ParticipantRole? ParticipantRole { get; set; }

        [Required(ErrorMessage = "GuestArrivedFrom is required")]
        public string? GuestArrivedFrom { get; set; } = string.Empty;

        public bool IsOutSider { get; set; } = false;

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
    }


    public class GuestResponse : GuestRequest
    {
        public Guid Id { get; set; }
    }


    public class GuestUpdateRequest : GuestRequest
    {
        public Guid Id { get; set; }
    }
}
