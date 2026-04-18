using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using task22.Models;

namespace task22.IService
{
    internal interface IprosductService
    {
        public abstract void GetDetails(Product product);
        public void PrintBasicInfo(Product product);
        
           
        
    }
}
