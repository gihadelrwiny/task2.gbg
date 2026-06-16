using task22.Models;
using task22.Services;

namespace task22
{
    internal class Program
    {
       
        static async Task Main(string[] args)
        {
            try
            {
               

                var cts = new CancellationTokenSource();
            
                ProductService productServise = new ProductService();
                //Bonus create 
                var products = new List<Product>
            {
                new Product(1, "chair", 22.00m),
                new Product(2, "table", 30.00m),
                new Product(3, "laptop", 500.00m),
                new Product(4, "phone", 300.00m),
                new Product(5, "mouse", 20.00m),
            };

                var tasks = products
                    .Select(p => productServise.CreateProductAsync(p, cts.Token))
                    .ToList();

                await Task.WhenAll(tasks);

                Console.WriteLine("All products created");

                ProductService.PrintCounters();


                //this whenall for getall and getbyid
                var allTask = productServise.GetAllProductsAsync(cts.Token);
                var byIdTask = productServise.GetProductByIdAsync(1, cts.Token);
                // this because i want the two method finish in the same time concurent
                cts.CancelAfter(TimeSpan.FromSeconds(2));

                await Task.WhenAll(allTask, byIdTask);
                // i have result of process here
                var all = await allTask;
                var productgetbyid = await byIdTask;
                Console.WriteLine(all.Count());
                Console.WriteLine(productgetbyid.Name);

            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Operation was cancelled due to timeout.");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }





        }
    }
}
