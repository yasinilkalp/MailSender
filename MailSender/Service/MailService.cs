using MailKit.Net.Smtp;
using MailSender.Models;
using MimeKit;
using System.Threading.Tasks;

namespace MailSender.Service
{
    public class MailService : IMailService
    {
        public async Task<MailResponse> SendAsync(MailSendRequest request)
        {
            MimeMessage message = new();

            MailboxAddress emailFrom = new(request.Settings.Name, request.Settings.Username);
            message.From.Add(emailFrom);

            request.Receivers.ForEach(to =>
            {
                message.To.Add(new MailboxAddress(to.Name, to.Address));
            });

            message.Subject = request.Subject;

            BodyBuilder emailBodyBuilder = new()
            {
                TextBody = request.Body
            };

            message.Body = emailBodyBuilder.ToMessageBody();


            SmtpClient client = new();
            client.Connect(request.Settings.Host, request.Settings.Port, request.Settings.useSSL);
            client.Authenticate(request.Settings.Username, request.Settings.Password);
            await client.SendAsync(message);
            client.Disconnect(true);
            client.Dispose();
            return new(); 
        }
    }
}
