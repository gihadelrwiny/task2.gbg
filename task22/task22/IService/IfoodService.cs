using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.Models;

namespace task22.IService
{
    internal interface IfoodService : IprosductService
    {
        public bool IsExpired(Product product);
      
    }
}
