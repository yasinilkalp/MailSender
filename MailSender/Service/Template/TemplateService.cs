using System;
using System.Reflection;
using System.Threading.Tasks;

namespace MailSender.Service.Template
{
    public class TemplateService<T> : ITemplateService<T>
    {
        public Task<string> CreateMessageContent(string body, T data)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
             
            foreach (PropertyInfo property in properties)
            {
                body = body.Replace("{{" + property.Name + "}}", property.GetValue(data)?.ToString() ?? "");
            }

            return Task.FromResult(body);
        }

    }
}
