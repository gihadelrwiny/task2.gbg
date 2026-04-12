using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22
{
    internal class Student
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public List<int> Scores { get; set; } = new List<int>();
        public int CalculateAverage()
        {
            if (Scores.Count == 0)
            {
                Console.WriteLine("NO Scores entered");
                return 0;
            }
            return Scores.Sum() / Scores.Count;
        }

        public string GetGrade()
        {
            int average = CalculateAverage();

            switch (average)
            {
                case >= 90:
                    return "A";
                case >= 80:
                    return "B";
                case >= 70:
                    return "C";
                case >= 60:
                    return "D";
                default:
                    return "F";

            }
        }


    }
}
