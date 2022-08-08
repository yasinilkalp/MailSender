namespace MailSender.Models
{
    public class MailSettings
    {
        public string Host { get; set; } 
        public int Port { get; set; } 
        public string Name { get; set; } 
        public string Username { get; set; } 
        public string Password { get; set; }
        public bool useSSL { get; set; }
    }
}
