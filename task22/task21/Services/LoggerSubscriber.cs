using Serilog;
using task21.EventArguments;

namespace task21.Services
{
    public class LoggerSubscriber
    {
        public  void OnStudentRegistered(StudentRegisteredEventArgs e)
        {
            Log.Information("[FILE LOGGER] Student {Id} Registered",e.Student.Id);
        }
    }
}
