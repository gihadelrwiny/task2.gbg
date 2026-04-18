using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
   public abstract class Product
    {
        public string Name { get; set; }
        public  int Price { get; set; }
        public abstract Category Category { get; }
        public Product(string Name,int Price)
        {
            if(string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price));
            }
            this.Name = Name;
            this.Price = Price;
        }

    }
}
