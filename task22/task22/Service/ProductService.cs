using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.IService;
using task22.Models;

namespace task22.Service
{
 public  abstract class ProductService : IprosductService
    {
        public abstract void GetDetails(Product product);
       

        public void PrintBasicInfo(Product product)
        {
            Console.WriteLine($"ProductName: {product.Name} ,ProductSize: {product.Price},ProductCategory: {product.Category}");
        }

      
    }
}
