using task22.GenericRepositories;
using task22.Models;
using task22.Repositories;

namespace task22
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            // =========================
            // 1) Result<T>
            // =========================

            var successResult = Result<int>.Ok(10);
            var failResult = Result<int>.Fail("Error happened");

            Console.WriteLine(successResult.IsSuccess); // True
            Console.WriteLine(successResult.Value);     // 10

            Console.WriteLine(failResult.IsSuccess);    // False
            Console.WriteLine(failResult.Error);        // Error happened


            // =========================
            // 2) Pair<T,U>
            // =========================

            var pair = new Pair<string, int>("Gihad", 22);

            var (name, age) = pair;

            Console.WriteLine(name); // Gihad
            Console.WriteLine(age);  // 22

            var swapped = pair.Swap();
            Console.WriteLine(swapped.First);  // 22
            Console.WriteLine(swapped.Second); // Gihad


            // =========================
            // 3) MinMax<T>
            // =========================

            var numbers = new List<int> { 5, 2, 9, 1, 7 };

            var minMax = new MinMax<int>().minmax(numbers);

            Console.WriteLine(minMax.min); // 1
            Console.WriteLine(minMax.max); // 9


            var words = new List<string> { "banana", "apple", "zebra", "cat" };

            var minMaxWords = new MinMax<string>().minmax(words);

            Console.WriteLine(minMaxWords.min); // apple
            Console.WriteLine(minMaxWords.max); // zebra


            // =========================
            // 4) Repository<T>
            // =========================

            var repo = new GenericRepository<Student>();

            repo.Add(new Student { Id = 1 });
            repo.Add(new Student { Id = 2 });

            var student = repo.GetById(1);
            Console.WriteLine(student?.Id);

            var all = repo.GetAll();
            foreach (var s in all)
            {
                Console.WriteLine(s.Id);
            }

            var found = repo.FindAll(x => x.Id > 1);
            foreach (var s in found)
            {
                Console.WriteLine(s.Id);
            }
        }




    }
    }

