using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
    public delegate T Transformer<T>(T input);
    public class TransformerDelegate
    {

        public void Test()
        {
            Transformer<int> transformer = x => x * 2;

            int result = transformer(5);

            Console.WriteLine(result);
        }


    }
}
