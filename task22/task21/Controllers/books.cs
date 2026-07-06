using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using task21.DTO;
using task21.Models;

namespace task21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class books : ControllerBase
    {

        private static List<book> bookList = new List<book>
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
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return Ok(bookList);

        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var book = bookList.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpGet("by-author")]
        public IActionResult GetByAuthor([FromQuery] string author)
        {
            var books = bookList.Where(s => s.Author.ToLower() == author.ToLower()).ToList();
            if (!books.Any()) return NotFound();
            return Ok(books);
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateBook([FromBody]BookCreatedDto book)
        {
            var bookcreated = new book
            {
                Id = bookList.Any() ? bookList.Max(x => x.Id) + 1 : 1,
                Author = book.Author,
                Name = book.Name,
                Price = book.Price,
                IsAvailable = true,

            };
            bookList.Add(bookcreated);
            return CreatedAtAction(nameof(GetById), new { id = bookcreated.Id }, bookcreated);

        }
        [HttpDelete( "{id}")]
        [Authorize]
        public IActionResult DeleteBookById(int id)
        {
            var book = bookList.FirstOrDefault(s => s.Id == id);
            if (book == null) return NotFound();
            bookList.Remove(book);
            return NoContent();

        }
        [HttpGet("available")]
        [AllowAnonymous]
        public IActionResult GetAvailableBooks()
        {
            var availableBooks = bookList
                .Where(b => b.IsAvailable)
                .ToList();

            return Ok(availableBooks);
        }

    }
}
