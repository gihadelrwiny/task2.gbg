using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.Models;

namespace task22.Data
{
    internal class ProductSeedData
    {
        public class ProductSeeder
        {
            public List<Product> SeedProducts()
            {
                var products = new List<Product>();


                var tshirt = new Clothing("T-Shirt", 250, "M");
                var jeans = new Clothing("Jeans", 600, "L");
                var jacket = new Clothing("Jacket", 1200, "XL");

                products.Add(tshirt);
                products.Add(jeans);
                products.Add(jacket);


                var burger = new Food("Burger", 80, DateTime.Now.AddDays(2));
                var pizza = new Food("Pizza", 150, DateTime.Now.AddDays(1));
                var chocolate = new Food("Chocolate", 40, DateTime.Now.AddMonths(6));

                products.Add(burger);
                products.Add(pizza);
                products.Add(chocolate);


                var phone = new Eloctronics("iPhone", 30000, 20);
                var laptop = new Eloctronics("Dell Laptop", 45000, 65);
                var tv = new Eloctronics("Samsung TV", 20000, 120);

                products.Add(phone);
                products.Add(laptop);
                products.Add(tv);

                return products;
            }
        }
    }
}