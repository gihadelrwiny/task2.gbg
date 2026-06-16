using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using task22.Models;

namespace task22.Services
{
    public class ProductService
    {
       private List<Product> _products = new List<Product>();
        private static ConcurrentDictionary<string, int> _counter = 
            new ConcurrentDictionary<string, int>();
        public void increment(string methodname)
        {
            _counter.AddOrUpdate(methodname, 1, (key, oldValue) => oldValue + 1);

        }
        public async Task CreateProductAsync(Product product,CancellationToken ct = default)
        {
            increment(nameof(CreateProductAsync));
            ct.ThrowIfCancellationRequested();
           await  Task.Delay(5000,ct);
            _products.Add(product);
          
        }
       public async Task DeleteProductAsync(int Id, CancellationToken ct = default)
        {
            increment(nameof(DeleteProductAsync));
          ct.ThrowIfCancellationRequested();
            await Task.Delay(5000, ct);
            var product = _products.FirstOrDefault(s => s.Id == Id);
            if (product == null)
            {
                throw new KeyNotFoundException("There is no product with this id");
            }
            _products.Remove(product);
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync( CancellationToken ct = default)
        {
            increment(nameof(GetAllProductsAsync));
           ct.ThrowIfCancellationRequested();
            await Task.Delay(5000, ct  );
            return _products.ToList(); ;
        }
        public async Task<Product> GetProductByIdAsync(int Id, CancellationToken ct = default)
        {
            increment(nameof(GetProductByIdAsync));
           ct.ThrowIfCancellationRequested();
            await Task.Delay(5000, ct);
            var product = _products.FirstOrDefault(s => s.Id == Id);
            if (product == null)
            {
                throw new KeyNotFoundException("There is no product with this id");
            }
            return product;

        }
        public static void PrintCounters()
        {
            foreach (var item in _counter)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }




    }
}
