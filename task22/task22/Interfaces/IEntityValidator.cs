using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Interfaces
{
    public  interface IEntityValidator<in T>
    {
        bool Validate(T entity);

    }
}
