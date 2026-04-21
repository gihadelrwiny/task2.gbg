using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.IServices;
using task22.Models;

namespace task22.Services
{
    internal class GenerateInVoice : IgenerateInvoid
    {
        public string GenerateInvoid(Order order)
        {
            return $"Invoice for Order {order.Id}\nCustomer: {order.CustomerEmail}\nAmount: {order.TotalAmount:C}";

        }
    }
}
