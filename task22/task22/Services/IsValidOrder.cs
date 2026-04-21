using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.IServices;
using task22.Models;

namespace task22.Services
{
    internal class IsValidOrder : Iisvalidorder
    {
        //rafactoring: this method is responsible for validating the order object, SingleResponsibilityPrinciple
        public void Isvalidorder(Order order)
        {
            if (order.TotalAmount <= 0)
            {
                throw new ArgumentOutOfRangeException("Order total must be greater than zero.");
            }

            if (!order.CustomerEmail.Contains("@")|| string.IsNullOrWhiteSpace(order.CustomerEmail) )
            {
             
                throw new ArgumentException("Invalid customer email address.");
            }
            if (!Enum.IsDefined(typeof(ShopingType), order.ShippingType)) //refactor to ensure that the shipping type is valid
            {
                
                throw new InvalidOperationException("Invalid shipping type state");

            }
           

        }
    }
}
