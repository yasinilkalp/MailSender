using System.Collections.Generic;

namespace MailSender.Models
{
    public abstract class MailSendRequest
    {
        public MailSettings Settings { get; set; }
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
