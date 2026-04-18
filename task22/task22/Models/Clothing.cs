using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
    internal class Clothing : Product
    {
        public string Size { get; set; }

        public override Category Category =>Category.Clothing;
        public Clothing(string Name, int Price,string size) : base(Name, Price)
        {
            this.Size = size;
        }

   
    }
}
