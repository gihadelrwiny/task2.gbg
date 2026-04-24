using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using task22.interfaces.IRepository;
using task22.interfaces.IServices;
using task22.Models;

namespace task22.Services
{
    internal class BorrowingService : IBorrowable
    {
        private readonly IBookRepository _bookRepository;
        private readonly INotifier _inotifier;
        public BorrowingService(IBookRepository bookRepository, INotifier inotifier)
        {
            _bookRepository = bookRepository;
            _inotifier = inotifier;
        }

        public void Borrow(Member member, Book _book)
        {
            if (member == null) throw new ArgumentNullException("member cant be null ");        
            if (_book == null) throw new ArgumentNullException("Book not found");
            if (_book.IsAvailable)
            {
                _book.IsAvailable = false;        
                member.BorrowedBooks.Add(_book);
                _inotifier.Notify($"Book '{_book.Title}' has been borrowed by {member.Name}.");
            }
            else
            {
                
                _inotifier.Notify($"Sorry, the book '{_book.Title}' is currently unavailable.");
            }

        }

        public void Return(Member member, Book _book)
        {
            if (member == null) throw new ArgumentNullException("member cant be null ");
         
            if (_book == null) throw new ArgumentNullException("Book not found");
            if (member.BorrowedBooks.Contains(_book))
            {
                _book.IsAvailable = true;
                member.BorrowedBooks.Remove(_book);
                _inotifier.Notify($"Book '{_book.Title}' has been returned by {member.Name}.");
            }
        }
    }
}
