using MailKit.Net.Smtp;
using MimeKit;

namespace IdentityFromScratch.Services;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task SendEmailAsync(string emailAddress, string subject, string htmlMessage)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_configuration["EmailConfiguration:SmtpUsername"]));
        email.To.Add(MailboxAddress.Parse(emailAddress));
        email.Subject = subject;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };
        
        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_configuration["EmailConfiguration:SmtpServer"], 
            int.Parse(_configuration["EmailConfiguration:SmtpPort"]), 
            MailKit.Security.SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_configuration["EmailConfiguration:SmtpUsername"], 
            _configuration["EmailConfiguration:SmtpPassword"]);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}