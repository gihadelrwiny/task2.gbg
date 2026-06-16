using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.Interfaces;

namespace task22.Validators
{
    public class ValidatorId : IEntityValidator<IHasId>
    {
        public bool Validate(IHasId entity)
        {
            
            return entity.Id > 0;
        }
    }
}
