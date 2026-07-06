using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
     public class filter
    {
        public IEnumerable<T> FindAll<T>(IList<T> list, Predicate<T> makefilter)
        {
            for(int i=0;i<list.Count; i++)
            {
                if (makefilter(list[i]))
                    yield return list[i];
            }
        }
    }
}
