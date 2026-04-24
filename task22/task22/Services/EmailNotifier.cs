using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.interfaces.IServices;

namespace task22.Services
{
    internal class EmailNotifier : INotifier
    {
        public void Notify(string message)
        {
            Console.WriteLine($"[EMAIL] Sending: {message}");
        }
    }
}
