using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{

    public delegate void Loggers(string message);
    public class logger
    {
        public static void FileLogger(string message)
        {
            Console.WriteLine($"Save to File: {message}");
        }

        public static void ConsoleLogger(string message)
        {
            Console.WriteLine($"Console: {message}");
        }

        public static void ErrorLogger(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
        public void log()
        {
            Loggers loggers = FileLogger;

            loggers += ConsoleLogger;
            loggers += ErrorLogger;
            loggers("Database Connected");
        }
    }
}
