using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MailSender.Service.Template
{
    public class TemplateService : ITemplateService
    {
        public Task<string> CreateMessageContent(string body, string modelJson)
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(modelJson); 
              
            foreach (var property in dict)
            {
                body = body.Replace("{{" + property.Key + "}}", property.Value ?? "");
            } 

            return Task.FromResult(body);
        }

    }
}
