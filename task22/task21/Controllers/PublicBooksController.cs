using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task21.Models;

namespace task21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicBooksController : ControllerBase
    {
        private static List<book> bookList = new()
        {
            new book
            {
                Id = 1,
                Name = "Clean Code",
                Price = 300,
                Author = "Robert Martin",
                IsAvailable = true
            },
            new book
            {
                Id = 2,
                Name = "C# Basics",
                Price = 200,
                Author = "John Doe",
                IsAvailable = true
            }
        };

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(bookList);
        }
    }
}
