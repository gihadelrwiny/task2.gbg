using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task21.Models;

namespace task21.Controllers
{
    /// <summary>
    /// Version 2 of the Books API.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/books")]
    public class BooksV2Controller : ControllerBase
    {
        private static readonly List<book> bookList = new List<book>
{
    new book
    {
        Id = 1,
        Name = "Clean Code",
        Author = "Robert Martin",
        Price = 300,
        IsAvailable = true
    },
    new book
    {
        Id = 2,
        Name = "C# Basics",
        Author = "John Doe",
        Price = 200,
        IsAvailable = false
    }
};


        /// <summary>
        /// Returns all books with a message indicating API version.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                Version = "2.0",
                Message = "Welcome to Books API V2",
                Count = bookList.Count,
                Data = bookList
            });
        }

        /// <summary>
        /// Returns only available books.
        /// </summary>
        [HttpGet("available")]
        [Authorize(Roles = "User")]
        public IActionResult GetAvailableBooks()
        {
            return Ok(bookList.Where(x => x.IsAvailable));
        }

        /// <summary>
        /// Search books by name.
        /// </summary>
        [HttpGet("search")]
        [Authorize(Roles = "User")]
        public IActionResult Search(string name)
        {
            var result = bookList.Where(x =>
                x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            return Ok(result);
        }
    }
}

