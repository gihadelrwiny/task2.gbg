using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task22.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static string Repeat(this string str, int n)
        {
            string result = "";

            for (int i = 0; i < n; i++)
                result += str;

            return result;
        }

        public static string Truncate(this string str, int length)
        {
            if (str.Length <= length)
                return str;

            return str.Substring(0, length);
        }

        public static string ToSlug(this string str)
        {
            return str.ToLower().Replace(" ", "-");
        }
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                if (str[left] != str[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}