using MailKit.Net.Smtp;
using MailSender.Models;
using MimeKit;
using System.Threading.Tasks;

namespace MailSender.Service.Mail
{
    public class MailService : IMailService
    {
        private readonly static string Host = MailSettings.Host;
        private readonly static int Port = MailSettings.Port;
        private readonly static string Name = MailSettings.Name;
        private readonly static string Username = MailSettings.Username;
        private readonly static string Password = MailSettings.Password;
        private readonly static bool UseSSL = MailSettings.UseSSL;

        public async Task<MailResponse> SendAsync(MailSendRequest request)
        {
            try
            {
                MimeMessage message = new();

                MailboxAddress emailFrom = new(Name, Username);
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
                client.Connect(Host, Port, UseSSL);
                client.Authenticate(Username, Password);
                await client.SendAsync(message);
                client.Disconnect(true);
                client.Dispose();
                return MailResponse.Success();
            }
            catch (System.Exception ex)
            {
                return MailResponse.Error(ex.Message);
            }
        }
    }
}
