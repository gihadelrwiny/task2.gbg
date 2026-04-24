using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
    public class EBook: LibraryItem
    {
        public double FileSizeMB { get; set; }
        public EBook(string title, string author, string isbn, double fileSizeMB)
        {
            if (fileSizeMB <= 0) throw new ArgumentException("File size must be greater than zero.", nameof(fileSizeMB));
            Title = title;
            Author = author;
            ISBN = isbn;
            FileSizeMB = fileSizeMB;
        }
        public override string GetDetails()
        {
            return $"EBook: {Title} by {Author} — File Size: {FileSizeMB}MB";
        }
    }
}
