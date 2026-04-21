using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.IServices;
using task22.Models;

namespace task22.Services
{
    internal class SaveOrder : ISaveOrder
    {
        public void saveOrder(Order order)
        {
            Console.WriteLine($"Saving order {order.Id} to database.");
        }
    }
}
