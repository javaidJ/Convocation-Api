using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Application.RRModels
{
    public class MemberRequest
    {
        public Guid EntityId { get; set; }


        public Module Module { get; set; }


        public JobRole JobRole { get; set; }

        public Guid ConvocationId { get; set; }
    }

    public class MemberResponse : MemberRequest
    {
        public Guid Id { get; set;}

        public string Name { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public string Email { get; set; } = string.Empty;

        public string ContactNo { get; set; } = string.Empty;
    }

    public class MemberUpdate : MemberRequest
    {
        public Guid? Id { get; set; }
    }
}
