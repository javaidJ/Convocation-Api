using IUSTConvocation.Application.Abstractions.IEmailService;
using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using Microsoft.Extensions.Options;

namespace IUSTConvocation.Infrastructure.EmailService.MailJetServices;

public class MailJetEmailService : IEmailService
{
    private readonly MailJetOptions options;

    public MailJetEmailService(IOptions<MailJetOptions> options)
    {
        this.options = options.Value;
    }

    public async Task<bool> SendEmailAsync(MailSetting settings)
    {
        MailjetClient client = new(options?.ApiKey, options?.SecretKey);

        var email = new TransactionalEmailBuilder()
            .WithFrom(new SendContact(options?.FromEmail))
            .WithSubject(settings.Subject)
            .WithHtmlPart(settings.Body)
            .WithTo(new SendContact(settings.To.FirstOrDefault()))
            .Build();



        var response = await client.SendTransactionalEmailAsync(email);
        return
            response?.Messages?.FirstOrDefault()?.Status is not null 
            ?
            response?.Messages?.FirstOrDefault()?.Status == "success"
            : 
            false;
    }
}
