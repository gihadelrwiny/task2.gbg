using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Interfaces
{
    public interface IReadableRepository<out T>
    {
         IEnumerable<T> GetAll();
         T GetById(int id);
        
        
    }
}
