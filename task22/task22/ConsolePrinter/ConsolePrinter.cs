using System;
using System.Collections.Generic;
using task22.GenericRepositories;
using task22.Interfaces;
using task22.Models;
using task22.Repositories;
using task22.Validators;

namespace task22
{
    public static class ConsolePrinter
    {
        // ── Helpers ────────────────────────────────────────────────
        private static void PrintHeader(string title)
        {
            int width = 42;
            string line = "─".PadRight(width, '─');
            string top = $"┌{line}┐";
            string bot = $"└{line}┘";
            int pad = (width - title.Length) / 2;
            string mid = $"│{new string(' ', pad)}{title}{new string(' ', width - pad - title.Length)}│";

            Console.WriteLine();
            Console.WriteLine(top);
            Console.WriteLine(mid);
            Console.WriteLine(bot);
        }

        private static void PrintRow(string label, object value)
        {
            Console.WriteLine($"  ├─ {label,-18} : {value}");
        }

        private static void PrintItem(string value)
        {
            Console.WriteLine($"  │  ● {value}");
        }

        private static void PrintDivider()
        {
            Console.WriteLine($"  ├{"─".PadRight(38, '─')}");
        }

        private static void PrintFooter()
        {
            Console.WriteLine($"  └{"─".PadRight(38, '─')}");
        }

        // ── 1) Result<T> ───────────────────────────────────────────
        public static void PrintResult()
        {
            PrintHeader("1  ·  Result<T>");

            var successResult = Result<int>.Ok(10);
            var failResult = Result<int>.Fail("Error happened");

            Console.WriteLine("  │  [ Success ]");
            PrintRow("IsSuccess", successResult.IsSuccess);
            PrintRow("Value", successResult.Value);
            PrintDivider();
            Console.WriteLine("  │  [ Fail ]");
            PrintRow("IsSuccess", failResult.IsSuccess);
            PrintRow("Error", failResult.Error);
            PrintFooter();
        }

        // ── 2) Pair<T,U> ──────────────────────────────────────────
        public static void PrintPair()
        {
            PrintHeader("2  ·  Pair<T, U>");

            var pair = new Pair<string, int>("Gihad", 22);
            var (name, age) = pair;

            Console.WriteLine("  │  [ Original ]");
            PrintRow("First", name);
            PrintRow("Second", age);
            PrintDivider();

            var swapped = pair.Swap();
            Console.WriteLine("  │  [ Swapped ]");
            PrintRow("First", swapped.First);
            PrintRow("Second", swapped.Second);
            PrintFooter();
        }

        // ── 3) MinMax<T> ──────────────────────────────────────────
        public static void PrintMinMax()
        {
            PrintHeader("3  ·  MinMax<T>");

            var numbers = new List<int> { 5, 2, 9, 1, 7 };
            var minMax = new MinMax<int>().minmax(numbers);

            Console.WriteLine("  │  [ int list : 5 2 9 1 7 ]");
            PrintRow("Min", minMax.min);
            PrintRow("Max", minMax.max);
            PrintDivider();

            var words = new List<string> { "banana", "apple", "zebra", "cat" };
            var minMaxWords = new MinMax<string>().minmax(words);

            Console.WriteLine("  │  [ string list ]");
            PrintRow("Min", minMaxWords.min);
            PrintRow("Max", minMaxWords.max);
            PrintFooter();
        }

        // ── 4) Repository<T> ──────────────────────────────────────
        public static void PrintRepository()
        {
            PrintHeader("4  ·  GenericRepository<T>");

            var repo = new GenericRepository<Student>();
            repo.Add(new Student { Id = 1 });
            repo.Add(new Student { Id = 2 });

            var student = repo.GetById(1);
            Console.WriteLine("  │  [ GetById(1) ]");
            PrintRow("Student.Id", student?.Id);
            PrintDivider();

            Console.WriteLine("  │  [ GetAll() ]");
            foreach (var s in repo.GetAll())
                PrintItem($"Id = {s.Id}");
            PrintDivider();

            Console.WriteLine("  │  [ FindAll(x => x.Id > 1) ]");
            foreach (var s in repo.FindAll(x => x.Id > 1))
                PrintItem($"Id = {s.Id}");
            PrintFooter();
        }

        // ── 5) EventQueue<T> ──────────────────────────────────────
        public static void PrintQueue()
        {
            PrintHeader("5  ·  EventQueue<T>");

            var queue = new EventQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine("  │  [ Enqueued : 1  2  3 ]");
            PrintDivider();

            PrintRow("Dequeue()", queue.Dequeue());

            queue.TryDequeue(out int val);
            PrintRow("TryDequeue()", val);
            PrintDivider();

            PrintRow("Count()", queue.Count());
            Console.WriteLine("  │  [ Remaining ]");
            foreach (var item in queue)
                PrintItem(item.ToString());
            PrintFooter();
        }

        // ── 6) Zip<T, U> ──────────────────────────────────────────
        public static void PrintZip()
        {
            PrintHeader("6  ·  Zip<T, U>");

            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<string> { "A", "B", "C" };
            var zipped = ZipHelper.Zip(list1, list2);

            Console.WriteLine("  │  [ int ]   [ string ]");
            Console.WriteLine($"  ├{"─".PadRight(38, '─')}");
            foreach (var p in zipped)
                Console.WriteLine($"  │    {p.First,-8}  ──►  {p.Second}");
            PrintFooter();
        }

        // ── 7) BoxingDemo<T> ──────────────────────────────────────
        public static void PrintBoxing()
        {
            PrintHeader("7  ·  BoxingDemo<T>");

            bool b1 = new BoxingDemo<int>().isvalueorreference(10);
            Console.WriteLine("  │  [ int ]");
            PrintRow("Value type?", b1 ? "✔ yes" : "✘ no");
            PrintDivider();

            bool b2 = new BoxingDemo<string>().isvalueorreference("hello");
            Console.WriteLine("  │  [ string ]");
            PrintRow("Value type?", b2 ? "✔ yes" : "✘ no");
            PrintFooter();
        }

        // ── 8) Validator ──────────────────────────────────────────
        public static void PrintValidator()
        {
            PrintHeader("8  ·  ValidatorId");

            IEntityValidator<IHasId> validator = new ValidatorId();

            Student s1 = new Student { Id = 5 };
            Student s2 = new Student { Id = 0 };

            Console.WriteLine("  │  [ Student Id = 5 ]");
            PrintRow("Valid?", validator.Validate(s1));
            PrintDivider();

            Console.WriteLine("  │  [ Student Id = 0 ]");
            PrintRow("Valid?", validator.Validate(s2));
            PrintFooter();
        }
    }
}