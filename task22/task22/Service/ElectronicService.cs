using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.IService;
using task22.Models;

namespace task22.Service
{
    internal class ElectronicService : ProductService, IelectronicsService
    {
        public override void GetDetails(Product product)
        {
            
            var electronics =(Eloctronics )product;
            
                Console.WriteLine($"Name: {electronics.Name}");
                Console.WriteLine($"Price: {electronics.Price}");
                Console.WriteLine($"Power: {electronics.Power}");
            Console.WriteLine($"Category: {electronics.Category}");
            Console.WriteLine("------------------------------");


        }

        public void TurnOn()
        {
            Console.WriteLine("electronics is turn on");
        }
    }
}
