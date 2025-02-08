﻿namespace IUSTConvocation.Infrastructure.EmailService.MailJetServices;

public class MailJetOptions
{

    public string ApiKey { get; set; } = string.Empty;


    public string SecretKey { get; set; } = string.Empty;


    public string FromEmail { get; set; } = string.Empty;


    public string FromName { get; set; } = string.Empty;
}
