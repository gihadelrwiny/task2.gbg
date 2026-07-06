using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
    public static class NumberExtensions
    {
        public static bool IsPrime(this int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
        public static long Factorial(this int number)
        {
            if (number < 0)
                throw new ArgumentException("Number must be non-negative.");

            long result = 1;

            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
        public static bool IsInRange(this int number,int min,int max)
        {
            return number >= min && number <= max;
        }
    }
}
