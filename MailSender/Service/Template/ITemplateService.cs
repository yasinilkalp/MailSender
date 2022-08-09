using System.Threading.Tasks;

namespace MailSender.Service.Template
{
    public interface ITemplateService
    {
        Task<string> CreateMessageContent(string body, string modelJson);
    }
}
