using System.Data.SqlTypes;

namespace task22
{
    internal class Program
    {
        static int ReadValidateScore()
        {
            
            while (true)
            {
                var input = Console.ReadLine();          
                if (!int.TryParse(input,out int score) )
                {
                    Console.WriteLine("invalid input,please write number between 0 and 100");
                    continue;
                }
                if (score == -1)
                    return -1;
                if (score >= 0 && score<= 100)
                    return score;
                Console.WriteLine("Score must be 0-100");
            }
        }
     
      
        static string ReadValidateName()
        {
           
            while (true)
            {
                var name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)&&name.All(c=>char.IsLetter(c)||c==' '))
                {
                    return name;
                }
                Console.WriteLine("invalid input,please write a valid name");

            }
        }

        static void Main(string[] args)
        {
            Student student = new Student();
            Console.WriteLine("Enter your Name");
            student.Name =  ReadValidateName();
            student.Scores = new List<int>();
            // i use list to store scores because i dont know how many scores user will write
            //I design when user write (-1) so list ends and loop ends and calculate average and grade

            while (true)
            {
                Console.WriteLine("enter score or write -1 to end");
                int score = ReadValidateScore();
                if (score==-1)
                {
                    break;
                }
                student.Scores.Add(score);

            }  
            Console.WriteLine($"Student Name: {student.Name}");
            Console.Write("Scores: ");
            foreach(var item in student.Scores)
            {
                if(item == student.Scores.Last())
                {
                    Console.Write($"{item}");
                    continue;
                }
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.WriteLine($"Average: {student.CalculateAverage()}");
            Console.WriteLine($"Grade: {student.GetGrade()}");






        }
    }
}
