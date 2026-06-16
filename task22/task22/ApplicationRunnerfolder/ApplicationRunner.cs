using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.Models;
using task22.Services;

namespace task22.ApplicationRunnerfolder
{
    public static class ApplicationRunner
    {
        public static async Task RunAsync()
        {
            try
            {
                var cts = new CancellationTokenSource();

                ProductService productService = new ProductService();

                var products = new List<Product>
                {
                    new Product(1, "chair", 22.00m),
                    new Product(2, "table", 30.00m),
                    new Product(3, "laptop", 500.00m),
                    new Product(4, "phone", 300.00m),
                    new Product(5, "mouse", 20.00m),
                };

                var tasks = products
                    .Select(p => productService.CreateProductAsync(p, cts.Token))
                    .ToList();

                await Task.WhenAll(tasks);

                Console.WriteLine("All products created");

                ProductService.PrintCounters();

                var allTask = productService.GetAllProductsAsync(cts.Token);
                var byIdTask = productService.GetProductByIdAsync(1, cts.Token);

                cts.CancelAfter(TimeSpan.FromSeconds(2));

                await Task.WhenAll(allTask, byIdTask);

                var allProducts = await allTask;
                var product = await byIdTask;

                Console.WriteLine($"Products Count: {allProducts.Count()}");
                Console.WriteLine($"Product Name: {product.Name}");
            }
            catch (OperationCanceledException)
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
