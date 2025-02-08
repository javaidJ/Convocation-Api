#region using

using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using IUSTConvocation.Application.Abstractions.IPaymentGatewayService;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.Abstractions.JWT;
using IUSTConvocation.Application.Services;
using IUSTConvocation.Application.Utils;
using Microsoft.Extensions.DependencyInjection;


#endregion


namespace IUSTConvocation.Application;
public static class AssemblyReference
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, string webrootPath)
    {

        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IConvocationService, ConvocationService>();
        services.AddScoped<ISeatAllocationService, SeatAllocationService>();
        services.AddScoped<ISeatService, SeatService>();
      
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<ISeatService, SeatService>();
        services.AddScoped<ISeatAllocationService, SeatAllocationService>();
        services.AddScoped<IGownService, GownService>();
        services.AddScoped<IGownBookingService, GownBookingService>();
        services.AddScoped<IVenueService, VenueService>();
        services.AddScoped<IContactService, ContactService>();


        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSingleton<IFileService>(new FileService(webrootPath));


        return services;
    }

}
