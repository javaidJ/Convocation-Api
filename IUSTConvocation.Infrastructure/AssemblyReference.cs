using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IUSTConvocation.Application.Abstractions.IEmailService;
using IUSTConvocation.Infrastructure.EmailService.MailJetServices;

using IUSTConvocation.Application.Abstractions.Identity;
using KashmirService.Infrastructure.Identity;
using IUSTConvocation.Application.Abstractions.TemplateRenderer;
using IUSTConvocation.Infrastructure.TemplateRenderer;
using IUSTConvocation.Application.Abstractions.JWT;
using KashmirServices.Infrastructure.JWT;
using IUSTConvocation.Application.Abstractions.IPaymentGatewayService;
using IUSTConvocation.Infrastructure.RazorPayServices;

namespace IUSTConvocation.Infrastructure;

public static class AssemblyReference
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<MailJetOptions>(configuration.GetSection("MailJetOptionSection"));
        services.AddTransient<IEmailService, MailJetEmailService>();
        services.AddScoped<IEmailTemplateRenderer, EmailTemplateRenderer>();
        services.AddScoped<IJwtProvider, JwtProvider>();

        //services.AddScoped<CustomerService>();
        //services.AddScoped<PaymentIntentService>();
        //services.AddScoped<TokenService>();
        services.AddSingleton<IContextService, ContextService>();
        services.Configure<PaymentOptions>(configuration.GetSection("RazorPaySection"));
        services.AddScoped<IPaymentGatewayService, RazorPayService>();

        return services;
    }

}