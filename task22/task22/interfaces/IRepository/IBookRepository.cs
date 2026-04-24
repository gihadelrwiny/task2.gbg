using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.Models;

namespace task22.interfaces.IRepository
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        Book FindByISBN(string isbn);
        List<Book> GetAll();
    }
}
