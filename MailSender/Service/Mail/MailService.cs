using MailKit.Net.Smtp;
using MailKit.Security;
using MailSender.Models;
using MimeKit;
using System.IO;
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
        private readonly static SecureSocketOptions SecureSocket = MailSettings.SecureSocket;

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

                BodyBuilder emailBodyBuilder = new();

                if (request.BodyIsHtml)
                    emailBodyBuilder.HtmlBody = request.Body;

                if (!request.BodyIsHtml)
                    emailBodyBuilder.TextBody = request.Body;

                if (request.Attachments != null)
                    request.Attachments.ForEach(file =>
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        emailBodyBuilder.Attachments.Add(fileName, file.OpenReadStream());
                    });


                message.Body = emailBodyBuilder.ToMessageBody();


                SmtpClient client = new();
                client.Connect(Host, Port, SecureSocket);
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
