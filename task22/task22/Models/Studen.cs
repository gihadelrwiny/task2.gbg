using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.Interfaces;

namespace task22.Models
{
    public class Student : IHasId
    {
        public int Id { get; set; }
    }
}
