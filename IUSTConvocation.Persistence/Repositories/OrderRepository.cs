using IUSTConvocation.Application.Abstractions.IRepository;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Persistence.Repositories;

namespace IUSTConvocation.Persistence.Repositories
{
    public class OrderRepository: BaseRepository,IOrderRepository
    {
        private readonly ConvocationDbContext context;

        public OrderRepository(ConvocationDbContext context) : base(context)
        {
            this.context = context;
        }

        public Task<int> GetAppointments(AppOrder model)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveOrder(AppOrder model)
        {

            return ExecuteAsync<int>(@$"INSERT INTO AppOrders  VALUES 
                        (@Id, @OrderId,@UserId, @GownBookingId, @Receipt, @TotalAmount,
                        @CreatedAt, @Currency,@OrderStatus, @CreatedBy, @UpdatedBy, @CreatedOn, @UpdatedOn) ", model);
        }
    }
}

