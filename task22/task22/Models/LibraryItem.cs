using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
    public   abstract class LibraryItem
    {
        public string Title{ get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public abstract  string GetDetails();   

    }
}
