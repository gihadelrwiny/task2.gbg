using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.interfaces.IRepository;
using task22.interfaces.IServices;
using task22.Models;

namespace task22.Repository
{
   public  class BookRepository:IBookRepository ,Isearchable
    {
        private List<Book> books;
        public BookRepository()
        {
            books= new List<Book>();    
        }

        public  void AddBook(Book book)
        {
           books.Add(book);
        }
      public  Book FindByISBN(string isbn)
        {
            return books.FirstOrDefault(b => b.ISBN == isbn);
        }
      public  List<Book> GetAll()
        {
            return books;
        }

        public List<Book> Search(string Keywoard)
        {
            if (string.IsNullOrEmpty(Keywoard)) throw new ArgumentNullException("keywoard is null");
            return books.Where(b => b.Title.Contains(Keywoard, StringComparison.OrdinalIgnoreCase) || b.Author.Contains(Keywoard, StringComparison.OrdinalIgnoreCase)).ToList();
        }      
    }
}
