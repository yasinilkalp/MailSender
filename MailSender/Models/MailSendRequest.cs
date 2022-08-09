using System.Collections.Generic;
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
        public List<Receiver> Receivers { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
    public class Receiver
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
