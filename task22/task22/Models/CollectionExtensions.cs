using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
      public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T(this IEnumerable<T> sourse)
        {
            return sourse == null || !sourse.Any();
        }
        public static List<T> Shufle(this IList<T> source)
        {
            Random random = new Random();
            for(int i = source.Count - 1; i >= 0; i--)
            {
                int j = random.Next(i + 1);
                (source[i], source[j]) = (source[j], source[i]);
            }
        }
        
       public static void ForEach<T>(this IEnumerable<T> source,Action<T> action)
       {
                foreach (var item in source)
                {
                    action(item);
                }
       }
        public static IEnumerable<T> ToChunk<T>(this IEnumerable<T> list,int size)
        {
            for(int i = 0; i < list.Count; i++)
            {
                yield return list.Skip(i).Take(size).ToList();
            }
        }
        
    }
}
