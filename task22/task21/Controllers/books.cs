using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task21.context;
using task21.DTO;
using task21.Models;
using task21.Services;

namespace task21.Controllers
{
    /// <summary>
    /// Provides endpoints for managing books.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class books : ControllerBase
    {
        private readonly FinalJwtContext _context;

        public books(FinalJwtContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a book by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the book.</param>
        /// <returns>The requested book.</returns>
        /// <response code="200">Returns the requested book.</response>
        /// <response code="404">Book was not found.</response>
        /// <response code="401">User is not authenticated.</response>
        /// <response code="403">User does not have permission.</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>
        /// Retrieves books by author name.
        /// </summary>
        /// <param name="author">The author's name.</param>
        /// <returns>A list of books written by the specified author.</returns>
        /// <response code="200">Returns matching books.</response>
        /// <response code="404">No books found for the specified author.</response>
        /// <response code="401">User is not authenticated.</response>
        /// <response code="403">User does not have permission.</response>
        [HttpGet("by-author")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetByAuthor([FromQuery] string author)
        {
            var books = await _context.Books
                .Where(s => s.Author.ToLower() == author.ToLower())
                .ToListAsync();

            if (!books.Any())
                return NotFound();

            return Ok(books);
        }

        /// <summary>
        /// Creates a new book.
        /// </summary>
        /// <param name="book">The book information.</param>
        /// <returns>The newly created book.</returns>
        /// <response code="201">Book created successfully.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="401">User is not authenticated.</response>
        /// <response code="403">User does not have permission.</response>
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateBook([FromBody] BookCreatedDto book)
        {
            var bookcreated = new book
            {
                Author = book.Author,
                Name = book.Name,
                Price = book.Price,
                IsAvailable = true
            };

            _context.Books.Add(bookcreated);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = bookcreated.Id }, bookcreated);
        }

        /// <summary>
        /// Deletes a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>No content if the deletion succeeds.</returns>
        /// <response code="204">Book deleted successfully.</response>
        /// <response code="404">Book was not found.</response>
        /// <response code="401">User is not authenticated.</response>
        /// <response code="403">User does not have permission.</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [Authorize(Policy = "CanDeleteUsers")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(s => s.Id == id);

            if (book == null)
                return NotFound();

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Retrieves all available books.
        /// </summary>
        /// <returns>A list of available books.</returns>
        /// <response code="200">Returns available books.</response>
        /// <response code="401">User is not authenticated.</response>
        /// <response code="403">User does not have permission or does not satisfy the PremiumFeature policy.</response>
        [HttpGet("available")]
        [Authorize(Roles = "User")]
        [Authorize(Policy = "PremiumFeature")]
        public async Task<IActionResult> GetAvailableBooks()
        {
            var availableBooks = await _context.Books
                .Where(b => b.IsAvailable)
                .ToListAsync();

            return Ok(availableBooks);
        }

        /// <summary>
        /// Retrieves all books.
        /// </summary>
        /// <returns>A list of all books.</returns>
        /// <response code="200">Returns the list of books.</response>
        /// <response code="401">User is not authenticated.</response>
        /// <response code="403">User does not have permission.</response>
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAll([FromQuery] BookQueryParams parameters)
        {
            var query = _context.Books.AsQueryable();

            query = BookService.ApplyFilter(query, parameters);

            var totalCount = await query.CountAsync();

            query = BookService.ApplyPagination(query, parameters);

            var books = await query.ToListAsync();

            return Ok(new PagedResult<book>
            {
                Items = books,
                TotalCount = totalCount,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize
            });
        }
    }
}