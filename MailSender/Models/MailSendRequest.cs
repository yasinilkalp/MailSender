using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MailSender.Models
{
    public class MailSendRequest
    {
        public MailSendRequest()
        {

        }
        public MailSendRequest(List<Receiver> receivers, string subject, string body, bool bodyIsHtml = true)
        {
            Receivers = receivers;
            Subject = subject;
            Body = body;
            BodyIsHtml = bodyIsHtml;
        }
        public MailSendRequest(List<Receiver> receivers, string subject, string body, List<IFormFile> attachments, bool bodyIsHtml = true)
        {
            Receivers = receivers;
            Subject = subject;
            Body = body;
            BodyIsHtml = bodyIsHtml;
            Attachments = attachments;
        }

        public List<Receiver> Receivers { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool BodyIsHtml { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }

}
