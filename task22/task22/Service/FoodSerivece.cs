using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.IService;
using task22.Models;

namespace task22.Service
{
    internal class FoodSerivece : ProductService, IfoodService
    {
        public override void GetDetails(Product product)
        {
            var food = (Food)product;
            Console.WriteLine($"Name: {food.Name}");
                Console.WriteLine($"Price: {food.Price}");
                Console.WriteLine($"Expire Date: {food.ExpiryDate}");
            Console.WriteLine($"Category: {food.Category}");
            Console.WriteLine("------------------------------");


        }

        public bool IsExpired(Product product)
        {
            Food food= (Food)product;
            return DateTime.Now > food.ExpiryDate;
        }
    }
}
