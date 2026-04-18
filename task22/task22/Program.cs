using task22.Models;
using task22.Service;
using task22.Services;
using static task22.Data.ProductSeedData;

namespace task22
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            var seeder = new ProductSeeder();
            List<Product> products = seeder.SeedProducts();

          
            IreportService reportService = new ReportService();

            // 📊 Run
            reportService.PrintAll(products);

            Console.ReadLine();





        }
    }
}
