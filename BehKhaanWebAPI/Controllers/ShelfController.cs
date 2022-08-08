using BehKhaan.Application.Interfaces;
using BehKhaan.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BehKhaanWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private readonly IModelValidator _validator;
        private readonly IShelfService _shelfService;
        private readonly IBook_ShelfService _book_ShelfService;
        private readonly IUserService _userService;

        public ShelfController(IModelValidator validator, IShelfService shelfService, 
            IBook_ShelfService book_ShelfService, IUserService userService)
        {
            _shelfService = shelfService;
            _book_ShelfService = book_ShelfService;
            _validator = validator;
            _userService = userService;
        }

        [HttpGet("get-all-shelfs")]
        public IActionResult GetAllShelfs()
        {
            var shelfs = _shelfService.GetShelfs();
            if (shelfs == null)
            {
                return NotFound();
            }
            return Ok(shelfs);
        }

        [HttpGet("get-shelf-by-id/{shelfId}")]
        public IActionResult GetShelfById(string shelfId)
        {
            var shelf = _shelfService.GetShelfById(shelfId);
            if (shelf == null)
            {
                return NotFound();
            }
            return Ok(shelf);
        }

        [HttpPost("add-shelf-for-user")]
        public IActionResult InsertShelfForUser(ShelfModel shelfModel)
        {
            var validateResult = _validator.CheckShelfModelValidation(shelfModel);
            if (!validateResult.Success)
            {
                return BadRequest(validateResult.Message);
            }
            var userWithShelfs = _userService.GetUserWithShelfsByUserId(shelfModel.UserId);
            bool isDuplicate = userWithShelfs.ShelfNames.Contains(shelfModel.Name);
            if (isDuplicate)
            {
                return BadRequest("This shelf is already exists for " + userWithShelfs.FullName + "!");
            }

            _shelfService.InsertShelfForUser(shelfModel);
            return Ok();
        }

        [HttpPut("update-shelf-by-id/{shelfId}")]
        public IActionResult EditShelf(string shelfId, string newShelfName)
        {
            var shelf = _shelfService.GetShelfById(shelfId);
            if (shelf == null)
            {
                return NotFound();
            }
            var userWithShelfs = _userService.GetUserWithShelfsByUserId(shelf.UserId);
            bool isExists = userWithShelfs.ShelfNames.Contains(newShelfName);
            if (isExists)
            {
                return BadRequest("This shelf is already exists for " + userWithShelfs.FullName + "!");
            }
            _shelfService.EditShelf(shelfId, newShelfName);
            return Ok();
        }

        [HttpDelete("delete-shelf-by-id/{shelfId}")]
        public IActionResult RemoveShelf(string shelfId)
        {
            var shelf = _shelfService.GetShelfById(shelfId);
            if (shelf == null)
            {
                return NotFound();
            }
            _shelfService.RemoveShelf(shelfId);
            return Ok();
        }

        [HttpGet("get-books-of-shelf/{shelfId}")]
        public IActionResult GetBooksOfShelf(string shelfId)
        {
            var shelf = _shelfService.GetShelfById(shelfId);
            if (shelf == null)
            {
                return NotFound();
            }
            var shelfWithBooks = _book_ShelfService.GetShelfWithBooksByShelfId(shelfId);
            return Ok(shelfWithBooks);
        }

        [HttpPost("add-book-to-shelf")]
        public IActionResult AddBookToShelf(Book_ShelfModel book_ShelfModel)
        {
            var validateResult = _validator.CheckBook_ShelfModelValidation(book_ShelfModel);
            if (!validateResult.Success)
            {
                return BadRequest(validateResult.Message);
            }
            var book_Shelf = _book_ShelfService.GetByBookIdAndShelfId(book_ShelfModel.BookId, book_ShelfModel.ShelfId);
            if (book_Shelf != null)
            {
                return BadRequest("Duplicate insert!");
            }
            _book_ShelfService.AddBookToShelf(book_ShelfModel);
            return Ok();
        }

        [HttpDelete("remove-book-from-shelf")]
        public IActionResult RemoveBookFromShelf(string bookId, string shelfId)
        {
            var book_Shelf = _book_ShelfService.GetByBookIdAndShelfId(bookId, shelfId);
            if (book_Shelf == null)
            {
                return NotFound();
            }
            _book_ShelfService.RemoveBookFromShelf(bookId, shelfId);
            return Ok();
        }
    }
}
