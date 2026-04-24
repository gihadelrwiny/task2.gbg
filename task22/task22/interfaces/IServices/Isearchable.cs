using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.Models;

namespace task22.interfaces.IServices
{
    public interface Isearchable
    {
        public List<Book> Search(string Keywoard);
    }
}
