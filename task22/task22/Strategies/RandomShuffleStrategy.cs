using task22.Interfaces;

namespace task22.Strategies
{
    public class RandomShuffleStrategy : ISortStrategy
    {
        public List<int> Sort(List<int> numbers)
        {
            Random random = new();

            for (int i = 0; i < numbers.Count; i++)
            {
                int j = random.Next(numbers.Count);

                (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            }

            return numbers;
        }
    }
}