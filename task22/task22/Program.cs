using task22.interfaces.IServices;
using task22.Models;
using task22.Repository;
using task22.Services;

namespace task22
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            
            var repo = new BookRepository();
            INotifier notifier = new MultinNotifier(
                new List<INotifier>
               {
               new LibraryNotifier(),
               new EmailNotifier()
              }
                  );
            var service = new BorrowingService(repo, notifier);

            // Add books
            repo.AddBook(new Book("Refactoring", "Martin Fowler", "101"));
            repo.AddBook(new Book("Clean Architecture", "Robert Martin", "102"));
            repo.AddBook(new Book("You Don't Know JS", "Kyle Simpson", "103"));
            repo.AddBook(new Book("The Art of Computer Programming", "Donald Knuth", "104"));
            try
            {
                // Add EBooks (Polymorphism)
                var items = new List<LibraryItem>
                 {
                  repo.FindByISBN("101"),
                   repo.FindByISBN("102"),
                  new EBook ("C# Advanced Guide", "Jon Skeet", "E101", 5.2),
                   new EBook ("System Design Basics", "Alex Xu", "E102", 4.6)
                  };
                
                // Polymorphism demo
                Console.WriteLine("\nLibrary Items Details:");
                foreach (var item in items)
                {
                    Console.WriteLine(item.GetDetails());
                }
                Console.WriteLine();
                items.Add(new EBook("Design Patterns in C#", "Erich Gamma", "E103", -1));
            } catch (Exception ex) {
                Console.WriteLine("Error adding items: " + ex.Message);
            }
            Console.WriteLine();
            // Create members
            var member1 = new Member(1,"Mona");
            var member2 = new Member(2,"Omar");

            // Borrow books
            try
            {
                service.Borrow(member1, repo.FindByISBN("101"));
                service.Borrow(member1, repo.FindByISBN("103"));
                service.Borrow(member2, repo.FindByISBN("102"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Borrow error: " + ex.Message);
            }
            // Return book
            try
            {
                service.Return(member1, repo.FindByISBN("101"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Return error: " + ex.Message);
            }
            // Show borrowed books
            Console.WriteLine($"\n{member1.Name}'s borrowed books:");
            foreach (var book in member1.BorrowedBooks)
            {
                Console.WriteLine($" - {book.Title}");
            }

            Console.WriteLine($"\n{member2.Name}'s borrowed books:");
            foreach (var book in member2.BorrowedBooks)
            {
                Console.WriteLine($" - {book.Title}");
            }

         




        }
    }
}
