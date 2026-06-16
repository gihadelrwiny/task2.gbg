using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.GenericRepositories
{
    public  class BoxingDemo<T>
    {
        public bool isvalueorreference(T value) 
        {
            // Check if T is a value type or a reference type
            // IsValueType is reflection property use in run time to check if T is a value type or reference type
            return typeof(T).IsValueType;
          
        }
        public void GetDefault(T value) {
            Console.WriteLine(default(T));
        }
        
    }
}
