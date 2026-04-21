using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.IServices
{
    public interface IDiscount
    {
        public decimal ApplyDiscount(decimal price);
    }
}
