using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.Interfaces;

namespace task22.Validators
{
    public class GenericValidator<T> : IEntityValidator<T>
    {
        //In so i can use it as input only //appledelegate=fruit
        public bool Validate(T entity)
        {
            Console.WriteLine($"Validating: {entity}");
            return true;
        }
    }
}
