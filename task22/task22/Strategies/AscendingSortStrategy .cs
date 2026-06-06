using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.Interfaces;

namespace task22.Strategies
{
    public class AscendingSortStrategy : ISortStrategy
    {
        public List<int> Sort(List<int> numbers)
        {
            numbers.Sort();
            return numbers;
        }
    }
}