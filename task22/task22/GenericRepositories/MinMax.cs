using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.GenericRepositories
{
    public class MinMax<T> where T:IComparable<T>
    {
        public (T min, T max) minmax(IEnumerable<T> items)
        {
            T Min = items.First();
            T Max = items.First();
            foreach (T item in items)
            {
                if (Min.CompareTo(item) > 0)
                {
                    Min = item;
                }
                if (Max.CompareTo(item) < 0)
                {
                    Max = item;
                }
            }
            return (Min, Max);

        }
    }
}
