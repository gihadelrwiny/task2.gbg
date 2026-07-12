using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using task21.context;
using task21.Models;

namespace Tests
{
    public class CustomWebApplicationFactory
     : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                    typeof(DbContextOptions<FinalJwtContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<FinalJwtContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDatabase");
                });

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();

                var db = scope.ServiceProvider.GetRequiredService<FinalJwtContext>();

                db.Database.EnsureCreated();

                db.Books.AddRange(
                    new book
                    {
                        Name = "Clean Code",
                        Author = "Robert Martin",
                        Price = 300,
                        IsAvailable = true
                    },
                    new book
                    {
                        Name = "C# Basics",
                        Author = "John",
                        Price = 200,
                        IsAvailable = true
                    });

                db.SaveChanges();
            });
        }
    }
}