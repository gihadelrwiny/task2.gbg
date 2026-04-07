namespace task22
{
    internal class Program
    {
        static int[] ReadValidateScore()
        {
            int[] arr = new int[5];
            for(int i = 0; i < 5; i++)
            {
                int c;
               
                if(!int.TryParse(Console.ReadLine(), out c))
                {
                    Console.WriteLine("Invalid input");
                    i--;
                    continue;
                }
                if (c < 0 || c > 100)
                {
                    Console.WriteLine("Invalid input");
                    i--;
                    continue;
                    
                }
                arr[i] = c;
            }
            return arr;
        }
        static int CalculateAverage(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++) { 
                sum+= arr[i];
            }
            return sum/arr.Length;

        }
        static string GetStringGrade(int avr)
        {
            switch (avr)
            {
                case >=90:
                    return "A";                
                case  >= 80:
                    return "B";                 
                case >= 70:
                    return "C";                 
                case >= 60:
                    return "D";                
                default:
                    return "F";
                  
            }
        }
        static void PrintReport(int[] arr, int avr, string grade)
        {
            Console.Write("Scores: ");
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine($"avrage: {avr}");
            Console.WriteLine($"grade: {grade}");
        }
        static void Main(string[] args)
        {
            int[] arr = ReadValidateScore(); 
            int avr= CalculateAverage(arr);
            string s= GetStringGrade(avr);
            PrintReport(arr, avr, s);
            
            



        }
    }
}
