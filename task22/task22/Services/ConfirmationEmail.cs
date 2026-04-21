using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.IServices;
using task22.Models;

namespace task22.Services
{
    internal class ConfirmationEmail : IconfirmationEmail
    {
        public void SendConfirmationEmail(Order order)
        {

            Console.WriteLine($"Sending confirmation email to {order.CustomerEmail} for order {order.Id}.");
        }
    }
}
