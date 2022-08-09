using System.Threading.Tasks;

namespace MailSender.Service.Template
{
    public interface ITemplateService<T>
    {
        Task<string> CreateMessageContent(string body, T data);
    }
}
