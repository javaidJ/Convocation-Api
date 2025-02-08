using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Application.Abstractions.IRepository;
using IUSTConvocation.Application.Abstractions.IRepositories;

namespace IUSTConvocation.Persistence.Repositories
{
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        private readonly ConvocationDbContext context;

        public PaymentRepository(ConvocationDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
