namespace IdentityFromScratch.Services;

public interface IEmailSender
{
    Task SendEmailAsync(string emailAddress, string subject, string htmlMessage);
}