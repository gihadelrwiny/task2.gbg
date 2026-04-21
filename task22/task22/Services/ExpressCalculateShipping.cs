using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.IServices;
using task22.Models;

namespace task22.Services
{
    internal class ExpressCalculateShipping: IcalculateShipping
    {
        public decimal CalculateShipping(Order order)
        {
            return 14.99m;
        }
    }
}
