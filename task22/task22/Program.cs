using task22.interfaces;
using task22.models;

namespace task22
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            try
            {
               Book book1= new Book("The Great Gatsby", 180, 10.99m, 1925);
                book1.DisplayInfo();
                Book book2 = new Book("The Great Gatsby", -1, 10.99m, 2010);
                book2.DisplayInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Validation Error: {ex.Message}");

            }
            Console.WriteLine("-------------------------");
            try
            {
                Ebook ebook1 = new Ebook("Digital Fortress",  "PDF",5, 3);
                ebook1.DisplayInfo();
                Ebook ebook2 = new Ebook("Digital Fortress", "PDF", -1, 3);
                ebook2.DisplayInfo();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Validation Error: {ex.Message}");

            }
            Console.WriteLine("-------------------------");
            try
            {
             Magazine magazine1 = new Magazine("National Geographic", 202,  11,"Ahmed");
                magazine1.DisplayInfo();
                Magazine magazine2 = new Magazine("National Geographic", 202, 13, "mohamed");
                magazine2.DisplayInfo();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Validation Error: {ex.Message}");


            }
            Console.WriteLine("#############################################");
            try
            {
                List<IlibraryItem> libraryItems = new List<IlibraryItem>()
                {
                    new Magazine("National Geographic", 202, 11, "Ahmed"),
                    new Book("The Great Gatsby", 180, 10.99m, 1925),
                    new Ebook("Digital Fortress", "PDF", 5, 3)

                };
                foreach (var item in libraryItems)
                {
                    item.DisplayInfo();
                    item.BorrowItem();
                    Console.WriteLine("-------------------------");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Validation Error: {ex.Message}");
            }
                

       




        }
    }
}
