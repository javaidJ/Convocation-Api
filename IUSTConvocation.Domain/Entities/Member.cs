using IUSTConvocation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Domain.Entities
{
    public class Member :BaseModal
    {
        public Guid EntityId { get; set; }


        public Module Module { get; set; }


        public JobRole JobRole { get; set; }


        public Guid? ConvocationId { get; set; }


        [ForeignKey(nameof(ConvocationId))]
        public Convocation Convocation{ get; set; } = null!;
    }
}
