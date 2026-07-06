using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
  public static  class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value) =>
            string.IsNullOrEmpty(value);

        public static string Truncate(this string value,int maxlength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxlength ? value : value[..maxlength] + "..";
        }
        public static string ToSlug(this string value)
        {
            return value.ToLower().Replace(" ", "-");

        }
        public static bool IsPalindrome(this string value)
        {
            string reversed = new string(value.Reverse().ToArray());
            return value == reversed;
        }
        public static string Repeat(,this string value,int n)
        {
           return string.Concat(Enumerable.Repeat(value,n))
        }
           
        
    }
}
