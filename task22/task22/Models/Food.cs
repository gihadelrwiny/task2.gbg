using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
    internal class Food : Product
    {
        public DateTime ExpiryDate { get; set; }

        public override Category Category =>Category.Food;
        public Food(string Name, int Price, DateTime ExpiryDate) : base(Name, Price)
        {
          this.ExpiryDate = ExpiryDate;
        }
 
    }
}
