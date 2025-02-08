using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Domain.Entities
{
    public class Gown : BaseModal, IBaseModal
    {
        public string Color { get; set; } = null!;

        public int Quantity { get; set; }

        public GownSize Size { get; set; }

        public bool IsDeleted { get; set; }


        public int Charges { get; set; }

        public ICollection<GownBooking> GownBookings { get; set; } = null!;
    }
}
