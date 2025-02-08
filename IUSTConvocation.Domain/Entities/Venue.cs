using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Domain.Entities
{
    public class Venue : BaseModal
    {
        public string Name { get; set; } = string.Empty;

        public int TotalSeats { get; set; }

        public ICollection<Convocation> Convocations { get; set; }
    }
}
