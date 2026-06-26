using Microsoft.Extensions.Options;
using task21.Interfaces.Iservice;
using task21.Models;

namespace task21.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _options;

        public EmailService(IOptions<EmailOptions> options)
        {
            _options = options.Value;
        }
        public void SendEmail(string to)
        {
            Console.WriteLine(
                $"Sending email to {to} using {_options.SmtpHost}:{_options.Port} From {_options.FromAddress}");
        }
    }
}
