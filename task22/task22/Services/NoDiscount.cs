using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.IServices;

namespace task22.Services
{
    internal class NoDiscount: IDiscount    
    {
        public decimal ApplyDiscount(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be negative.");
            }
            return price;  //Refactoring: No discount applied, return the original price  LSP

        }
    }
}
