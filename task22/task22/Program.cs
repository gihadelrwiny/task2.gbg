using task22.Delegates;
using task22.Extensions;
using task22.Interfaces;
using task22.Models;
using task22.Pipeline;
using task22.Strategies;

namespace task22
{
    internal class Program
    {
        static void ConsoleLogger(string message)
        {
            Console.WriteLine($"Console: {message}");
        }

        static void FileLogger(string message)
        {
            File.AppendAllText("log.txt", message + Environment.NewLine);
        }

        static void ErrorLogger(string message)
        {
            Console.WriteLine($"Error: {message}");
        }

        static async Task Main(string[] args)
        {
            // ── Transformer Delegate  ────────────────────────────────────────────
            Console.WriteLine("\n=== Transformer Delegate ===");

            Transformer<string> upper = s => s.ToUpper();

            Console.WriteLine(upper("hello"));
            // ──Predicate<Student  ────────────────────────────────────────────
            Console.WriteLine("\n=== Predicate<Student> ===");

            List<Student> students =
            [
                new Student { Name = "Ali", Age = 20, GPA = 2.5 },
                 new Student { Name = "Sara", Age = 22, GPA = 3.7 },
                   new Student { Name = "Omar", Age = 24, GPA = 3.9 }
            ];

            Predicate<Student> filter =
                s => s.Age > 21 && s.GPA > 3;

            var result = students.FindAll(filter);

            result.ForEach(s => Console.WriteLine(s.Name));
            // ─ Multicast Logger  ────────────────────────────────────────────
            Console.WriteLine("\n=== Multicast Logger ===");

            Action<string> logger = ConsoleLogger;

            logger += FileLogger;
            logger += ErrorLogger;

            logger("Test Message");
            // ─  Strategy Pattern   ────────────────────────────────────────────
            Console.WriteLine("\n=== Strategy Pattern ===");

            List<int> numbers = new() { 5, 1, 8, 3, 2 };

            ISortStrategy strategy = new AscendingSortStrategy();

            Console.WriteLine(string.Join(", ", strategy.Sort(new List<int>(numbers))));

            strategy = new DescendingSortStrategy();

            Console.WriteLine(string.Join(", ", strategy.Sort(new List<int>(numbers))));

            strategy = new RandomShuffleStrategy();

            Console.WriteLine(string.Join(", ", strategy.Sort(new List<int>(numbers))));

            // ── StringExtensions ────────────────────────────────────────────
            Console.WriteLine("=== StringExtensions ===");

            string? nullStr = null;
            Console.WriteLine(nullStr.IsNullOrEmpty());       
            Console.WriteLine("".IsNullOrEmpty());               
            Console.WriteLine("hello".IsNullOrEmpty());          

            Console.WriteLine("ab".Repeat(3));                    
            Console.WriteLine("Hello World!".Truncate(8));       
            Console.WriteLine("C# Extension Methods".ToSlug());
            Console.WriteLine("level".IsPalindrome());
            Console.WriteLine("hello".IsPalindrome());

            // ── CollectionExtensions ────────────────────────────────────────
            Console.WriteLine("\n=== CollectionExtensions ===");

            int[] nums = [1, 2, 3, 4, 5, 6, 7];
            Console.WriteLine(nums.IsNullOrEmpty());              // False

            nums.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();

            foreach (var chunk in nums.ToChunks(3))
                Console.WriteLine($"[{string.Join(", ", chunk)}]");
          

            // ── NumberExtensions ────────────────────────────────────────────
            Console.WriteLine("\n=== NumberExtensions ===");
      
            Console.WriteLine(17.IsPrime());                   
            Console.WriteLine(5.Factorial());                    
            Console.WriteLine(5.IsInRange(1, 10));               

            Console.WriteLine($"Shuffled: [{string.Join(", ", nums.Shuffle())}]");
            Console.WriteLine($"Page 2 (size 3): [{string.Join(", ", nums.Paginate(2, 3))}]");
            // [4, 5, 6]

            Console.WriteLine("\n=== Async Pipeline<T> ===");

            var pipeline = new Pipeline<string>()
                .AddStep(async s =>
                {
                    await Task.Delay(100);
                    return s.Trim();
                })
                .AddStep(async s =>
                {
                    await Task.Delay(100);
                    return s.ToUpper();
                });

            string pipelineResult = await pipeline.ExecuteAsync("  hello world  ");

            Console.WriteLine(pipelineResult);





        }
    }
}
