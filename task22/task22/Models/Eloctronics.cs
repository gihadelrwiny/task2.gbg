using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
    internal class Eloctronics: Product
    {
        public int Power { get; set; }

        public override Category Category => Category.Electronics;
        public Eloctronics(string Name, int Price,int power) : base(Name, Price)
        {
            if(power < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(power));
            }
            this.Power = power;
        }

       
    }
}
