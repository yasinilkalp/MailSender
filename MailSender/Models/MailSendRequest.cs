using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MailSender.Models
{
    public class MailSendRequest
    {
        public MailSendRequest()
        {

        }
        public MailSendRequest(List<Receiver> receivers, string subject, string body)
        {
            Receivers = receivers;
            Subject = subject;
            Body = body;
        }
        public MailSendRequest(List<Receiver> receivers, string subject, string body, List<IFormFile> attachments)
        {
            Receivers = receivers;
            Subject = subject;
            Body = body;
            Attachments = attachments;
        }

        public List<Receiver> Receivers { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }

}
