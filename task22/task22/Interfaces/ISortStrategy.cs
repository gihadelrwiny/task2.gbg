using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Interfaces
{
    public interface ISortStrategy
    {
        List<int> Sort(List<int> numbers);
    }
}