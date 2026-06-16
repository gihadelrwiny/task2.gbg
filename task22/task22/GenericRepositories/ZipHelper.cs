using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.GenericRepositories
{


    public class ZipHelper
    {
        public static List<Pair<T, U>> Zip<T, U>(IEnumerable<T> first, IEnumerable<U> second)
        {
            var result = new List<Pair<T, U>>();

            var e1 = first.GetEnumerator();
            var e2 = second.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {
                result.Add(new Pair<T, U>(e1.Current, e2.Current));
            }

            return result;
        }
    }
}
