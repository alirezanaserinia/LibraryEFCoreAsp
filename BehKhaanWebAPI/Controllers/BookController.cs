using BehKhaan.Application.Interfaces;
using BehKhaan.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BehKhaanWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IBook_ShelfService _book_ShelfService;

        public BookController(IBookService bookService, IBook_ShelfService book_ShelfService)
        {
            _bookService = bookService;
            _book_ShelfService = book_ShelfService;
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

        [HttpGet("get-shelfs-of-book/id")]
        public IActionResult GetShelfsOfBook(string id)
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
            var bookWithShelfs = _book_ShelfService.GetBookWithShelfsByBookId(id);
            return Ok(bookWithShelfs);
        }
    }
}
