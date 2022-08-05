using BehKhaan.Application.Models;
using BehKhaan.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BehKhaanWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetBooks();
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(string id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("add-book")]
        public IActionResult InsertBook(BookModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bookService.InsertBook(bookModel);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult EditBook(string id ,BookModel bookModel)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bookService.EditBook(id, bookModel);
            return Ok();
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult RemoveBook(string id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bookService.RemoveBook(id);
            return Ok();
        }
    }
}
