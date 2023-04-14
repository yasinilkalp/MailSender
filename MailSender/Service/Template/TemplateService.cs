using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailSender.Service.Template
{
    public class TemplateService : ITemplateService
    {
        public Task<string> CreateMessageContent(string body, string modelJson)
        {
            if (string.IsNullOrEmpty(modelJson)) return Task.FromResult(body);

            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(modelJson);

            foreach (var property in dict)
            {
                if (property.Value?.GetType() == typeof(string))
                    body = body.Replace("{{" + property.Key + "}}", property.Value?.ToString() ?? "");
            }

            return Task.FromResult(body);
        }

    }
}
