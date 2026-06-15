using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.GenericRepositories
{
    public class Pair<T,U>
    {
        public T First { get; }
        public U Second { get;  }
        public Pair(T first, U second)
=> (First, Second) = (first, second);

        public void Deconstruct(out T first, out U second) => (first, second) = (First, Second);
        public Pair<U, T> Swap() => new Pair<U, T>(Second, First);
    
        
            
        
        
    }
}