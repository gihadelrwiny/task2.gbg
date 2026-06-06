using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Pipeline
{
    public class Pipeline<T>
    {
        private List<Func<T, Task<T>>> steps = new();

        public Pipeline<T> AddStep(Func<T, Task<T>> step)
        {
            steps.Add(step);
            return this;
        }

        public async Task<T> ExecuteAsync(T value)
        {
            foreach (var step in steps)
            {
                value = await step(value);
            }

            return value;
        }
    }
}
