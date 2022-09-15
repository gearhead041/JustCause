using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace JustCause.Services;

public class EmailService : IEmailSender
{
    //TODO check if functioning
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var emailToSend = new MimeMessage();
        emailToSend.From.Add(new MailboxAddress("EDS Registration Admin", AppProperties.AdminMail));
        emailToSend.To.Add(new MailboxAddress("First Last", email));
        emailToSend.Subject = subject;
        emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

        using var emailClient = new SmtpClient(new ProtocolLogger("smtp.txt"));
        await emailClient.ConnectAsync(AppProperties.MicrosoftSmtp, 587, SecureSocketOptions.StartTls);
        emailClient.Authenticate(AppProperties.AdminMail, AppProperties.AdminPassword);
        await emailClient.SendAsync(emailToSend);
        emailClient.Disconnect(true);

        return;
    }
}
