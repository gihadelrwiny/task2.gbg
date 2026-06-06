using task22.Interfaces;

namespace task22.Strategies
{
    public class DescendingSortStrategy : ISortStrategy
    {
        public List<int> Sort(List<int> numbers)
        {
            numbers.Sort();
            numbers.Reverse();
            return numbers;
        }
    }
}