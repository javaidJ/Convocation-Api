using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Domain.Entities
{
    public class GownBooking : BaseModal, IBaseModal
    {
        public Guid GownId { get; set; }

        public Guid EntityId { get; set; }

        public GownStatus GownStatus { get; set; }

        public bool IsCancelled { get; set; }

        public Guid? ConvocationId { get; set; }


        [ForeignKey(nameof(ConvocationId))]
        public Convocation Convocation { get; set; } = null!;


        [ForeignKey(nameof(GownId))]
        public Gown Gown { get; set; } = null!;
    }
}
