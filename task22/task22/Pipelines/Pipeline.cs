using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Pipelines
{
   public  class Pipeline
    {
        public async Task<T> Pipeline<T>(T input,params Func<T, Task<T>>[] steps)
        {
            T result = input;

            foreach (var step in steps)
            {
                result = await step(result);
            }

            return result;
        }
    }
}
