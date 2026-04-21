using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
    public enum ShopingType
    {
        //enumeration: ShopingType is an enumeration that defines the different types of shipping options--> this is more safe and readable than using magic numbers or strings
        Standard,
        Express,
        Free
    }
}
