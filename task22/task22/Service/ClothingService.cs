using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.IService;
using task22.Models;

namespace task22.Service
{
    internal class ClothingService : ProductService, IclothingService
    {
        public override void GetDetails(Product product)
        {
           
            var clothing = (Clothing)product;
            Console.WriteLine($"Name: {clothing.Name}");
                Console.WriteLine($"Price: {clothing.Price}");
                Console.WriteLine($"Size: {clothing.Size}");
            Console.WriteLine($"Category: {clothing.Category}");
            Console.WriteLine("------------------------------");



        }

        public bool IsAvailableInSize(Product product,string size)
        {
           return product is Clothing clothing && clothing.Size == size;
        }
    }
}
