using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Persistence.Repositories
{
    public class SeatRepository : BaseRepository, ISeatRepository, IBaseRepository
    {
        private readonly ConvocationDbContext context;
        public SeatRepository(ConvocationDbContext context) : base(context)
        {
            this.context = context;
        }

        //public async Task<IEnumerable<SeatResponse>?> GetAllSeatsByConvocation(Guid id)
        //{

        //    //var res1 = await QueryAsync<RegistrationResponse>(employeeRegistrationQuery, new { convocationId = id });
        //    //var res2 = await QueryAsync<RegistrationResponse>(studentRegistrationQuery, new { convocationId = id });
        //    //var res3 = await QueryAsync<RegistrationResponse>(guestRegistrationQuery, new { convocationId = id });

        //    //var registrationResponses = new List<RegistrationResponse>();
        //    //if (res1.Any())
        //    //    registrationResponses.AddRange(res1);
        //    //if (res2.Any())
        //    //    registrationResponses.AddRange(res2);
        //    //if (res3.Any())
        //    //    registrationResponses.AddRange(res3);
        //    //return registrationResponses;
        //}
    }
}
