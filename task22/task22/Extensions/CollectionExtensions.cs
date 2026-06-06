using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace task22.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }

        public static List<List<T>> ToChunks<T>(this IEnumerable<T> source, int size)
        {
            List<List<T>> result = new();
            List<T> chunk = new();

            foreach (var item in source)
            {
                chunk.Add(item);

                if (chunk.Count == size)
                {
                    result.Add(chunk);
                    chunk = new List<T>();
                }
            }

            if (chunk.Count > 0)
                result.Add(chunk);

            return result;
        }

        public static List<T> Shuffle<T>(this IEnumerable<T> source)
        {
            Random random = new();

            List<T> list = source.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                int j = random.Next(list.Count);

                (list[i], list[j]) = (list[j], list[i]);
            }

            return list;
        }

        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int page, int size)
        {
            return source.Skip((page - 1) * size).Take(size);
        }
    }
}

