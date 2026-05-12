using WebApplication2.Models;

namespace WebApplication3.Models
{
    public static class SeedData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (context.Categories.Any())
            {
                return; // DB has been seeded
            }
            var categories = new List<Category>
            {
                new Category { Name = "Electronics" },
                new Category { Name = "Books" },
                new Category { Name = "Clothing" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 999.99m, CategoryId = categories[0].CategoryId },
                new Product { Name = "Smartphone", Price = 499.99m, CategoryId = categories[0].CategoryId },
                new Product { Name = "Novel", Price = 19.99m, CategoryId = categories[1].CategoryId },
                new Product { Name = "T-Shirt", Price = 9.99m, CategoryId = categories[2].CategoryId }
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
