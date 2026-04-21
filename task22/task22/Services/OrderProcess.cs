using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.IServices;
using task22.Models;

namespace task22.Services
{
    internal class OrderProcess : IorderProcess
    {
        private readonly IcalculateShipping _icalculateShipping;
        private readonly IDiscount _idiscount;
        private readonly Iisvalidorder _isvalidorder;
        public OrderProcess(IcalculateShipping icalculateShipping, IDiscount idiscount, Iisvalidorder isvalidorder)
        {
            _icalculateShipping = icalculateShipping;
            _idiscount = idiscount;
            _isvalidorder = isvalidorder;
        }

        public void ProcessOrder(Order order)
        {

                _isvalidorder.Isvalidorder(order);
                decimal shippingCost = _icalculateShipping.CalculateShipping(order);
                decimal discountAmount = _idiscount.ApplyDiscount(order.TotalAmount);
                Console.WriteLine($"Order {order.Id} for {order.CustomerEmail} processed with total: {discountAmount + shippingCost:C}");
                Console.WriteLine($"Shipping cost: {shippingCost:C}");
                Console.WriteLine("-------------------------------------");

        }
    }
}
