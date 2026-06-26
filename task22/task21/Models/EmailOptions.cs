namespace task21.Models
{
    public class EmailOptions
    {
        public string SmtpHost { get; set; } = string.Empty;
        public int Port { get; set; }
        public string FromAddress { get; set; } = string.Empty;
    }
}
