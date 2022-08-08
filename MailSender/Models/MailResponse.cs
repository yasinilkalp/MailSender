namespace MailSender.Models
{
    public class MailResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public MailResponse()
        {
            IsSuccess = true;
        }
        public MailResponse(string message)
        {
            this.IsSuccess = false;
            this.Message = message;
        }
        public static MailResponse Error(string message) => new(message);
        public static MailResponse Success() => new();
    }
}