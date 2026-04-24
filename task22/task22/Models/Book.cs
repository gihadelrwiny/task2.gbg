using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
    public class Book:LibraryItem
    {
        public bool IsAvailable { get; set; }
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = true;
        }
        public override string GetDetails()
        {
            return $"Book: {Title} by {Author} — Available: {IsAvailable}";

        }
    }
}
