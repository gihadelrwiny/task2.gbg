using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.IServices;

namespace task22.Services
{
    internal class PercentageDiscount : IDiscount
    {
        private readonly decimal _percentage;

        public PercentageDiscount(decimal percentage)
        {
            if (percentage < 0 || percentage > 1)
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage must be between 0 and 1");
            _percentage = percentage;
        }
        public decimal ApplyDiscount(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be negative.");
            }
            return price - (price * _percentage);
        }
    }
}
