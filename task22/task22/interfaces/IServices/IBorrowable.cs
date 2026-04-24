using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.Models;

namespace task22.interfaces.IServices
{
    public interface IBorrowable
    {
        public void Borrow(Member member, Book book);
         public void Return(Member member, Book book);

    }
}
