using Microsoft.Extensions.Options;
using Serilog;
using task21.EventArguments;
using task21.Interfaces.Iservice;
using task21.Models;

namespace task21.Services
{
    public class EmailNotificationService 
    {

        public void OnStudentRegistered( StudentRegisteredEventArgs e)
        {
            Log.Information("Email sent to {Email}", e.Student.Email);
        }
    }
}
