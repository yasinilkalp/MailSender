namespace MailSender.Models
{
    public class MailSettings
    {
        public MailSettings()
        {

        }
        public MailSettings(string host, int port, string name, string userName, string password, bool useSSL)
        {
            Host = host;
            Port = port;
            Name = name;
            Username = userName;
            Password = password;
            UseSSL = useSSL;
        }
        public static string Host { get; set; }
        public static int Port { get; set; }
        public static string Name { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static bool UseSSL { get; set; }

        public static MailSettings SetConfig(string host, int port, string name, string userName, string password, bool useSSL) => new(host, port, name, userName, password, useSSL);
    }
}
