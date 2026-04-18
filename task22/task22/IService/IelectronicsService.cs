using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.IService
{
    internal interface IelectronicsService:IprosductService
    {
        public void TurnOn();
        

    }
}
