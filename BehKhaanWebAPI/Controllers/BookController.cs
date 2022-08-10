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
        private readonly IModelValidator _validator;
        private readonly IBookService _bookService;
        private readonly IBook_ShelfService _book_ShelfService;

        public BookController(IModelValidator validator, IBookService bookService, IBook_ShelfService book_ShelfService)
        {
            _validator = validator;
            _bookService = bookService;
            _book_ShelfService = book_ShelfService;
        }

        [HttpGet("books")]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetBooks();
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("books/{bookId}")]
        public IActionResult GetBookById(string bookId)
        {
            var book = _bookService.GetBookById(bookId);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("books/insert")]
        public IActionResult InsertBook(BookModel bookModel)
        {
            var validateResult = _validator.CheckBookModelValidation(bookModel);
            if (!validateResult.Success)
            {
                return BadRequest(validateResult.Message);
            }
            _bookService.InsertBook(bookModel);
            return Ok();
        }

        [HttpPut("books/{bookId}/update")]
        public IActionResult EditBook(string bookId ,BookModel bookModel)
        {
            var validateResult = _validator.CheckBookModelValidation(bookModel);
            if (!validateResult.Success)
            {
                return BadRequest(validateResult.Message);
            }
            var book = _bookService.GetBookById(bookId);
            if (book == null)
            {
                return NotFound();
            }
            _bookService.EditBook(bookId, bookModel);
            return Ok();
        }

        [HttpDelete("books/{bookId}/delete")]
        public IActionResult RemoveBook(string bookId)
        {
            var book = _bookService.GetBookById(bookId);
            if (book == null)
            {
                return NotFound();
            }
            _bookService.RemoveBook(bookId);
            return Ok();
        }

        [HttpGet("books/{bookId}/shelfs")]
        public IActionResult GetShelfsOfBook(string bookId)
        {
            var book = _bookService.GetBookById(bookId);
            if (book == null)
            {
                return NotFound();
            }
            var bookWithShelfs = _book_ShelfService.GetBookWithShelfsByBookId(bookId);
            return Ok(bookWithShelfs);
        }

        [HttpPut("")] // ??
        public IActionResult ChangeBookStudyState([FromQuery] Book_ShelfModel book_ShelfModel)
        {
            var validateResult = _validator.CheckBook_ShelfModelValidation(book_ShelfModel);
            if (!validateResult.Success)
            {
                return BadRequest(validateResult.Message);
            }
            var book_Shelf = _book_ShelfService.GetByBookIdAndShelfId(book_ShelfModel.BookId, book_ShelfModel.ShelfId);
            if (book_Shelf == null)
            {
                return NotFound();
            }
            _book_ShelfService.ChangeBookStudyState(book_ShelfModel);
            return Ok();
        }

        [HttpGet("books/mostpopular")]
        public IActionResult GetOrderedListOfBooksBasedOnUserReception()
        {
            var orderedListOfBooks = _bookService.GetOrderedListOfBooksBasedOnUserReception();
            if (orderedListOfBooks == null)
            {
                return NotFound();
            }
            return Ok(orderedListOfBooks);
        }
    }
}
