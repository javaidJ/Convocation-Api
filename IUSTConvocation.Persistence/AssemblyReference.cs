#region using
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IRepository;
using IUSTConvocation.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


#endregion


namespace IUSTConvocation.Persistence;

public static class AssemblyReference
{

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IConvocationRepository, ConvocationRepository>();
        services.AddScoped<ISeatRepository, SeatRepository>();
        services.AddScoped<ISeatAllocationRepository, SeatAllocationRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IGuestRepository, GuestRepository>();
        services.AddScoped<IRegistrationRepository, RegistrationRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<ISeatRepository, SeatRepository>();
        services.AddScoped<ISeatAllocationRepository, SeatAllocationRepository>();
        services.AddScoped<IGownRepository, GownRepository>();
        services.AddScoped<IGownBookingRepository, GownBookingRepository>();
        services.AddScoped<IVenueRepository, VenueRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddDbContextPool<ConvocationDbContext>(options => options
            .UseSqlServer(configuration.GetConnectionString(nameof(ConvocationDbContext))));


        return services;

    }

}