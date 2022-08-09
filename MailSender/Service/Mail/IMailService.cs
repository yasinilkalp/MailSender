using MailSender.Models;
using System.Threading.Tasks;

namespace MailSender.Service.Mail
{
    public interface IMailService
    {
        Task<MailResponse> SendAsync(MailSendRequest request);
    }
}
