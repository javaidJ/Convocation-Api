using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Persistence.Repositories
{
    public class VenueRepository : BaseRepository, IVenueRepository, IBaseRepository
    {
        private readonly ConvocationDbContext context;
        public VenueRepository(ConvocationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
