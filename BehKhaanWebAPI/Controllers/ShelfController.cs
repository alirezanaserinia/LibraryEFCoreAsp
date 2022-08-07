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
        private readonly IShelfService _shelfService;
        private readonly IBook_ShelfService _book_ShelfService;

        public ShelfController(IShelfService shelfService, IBook_ShelfService book_ShelfService)
        {
            _shelfService = shelfService;
            _book_ShelfService = book_ShelfService;
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

        [HttpGet("get-shelf-by-id/{id}")]
        public IActionResult GetShelfById(string id)
        {
            var shelf = _shelfService.GetShelfById(id);
            if (shelf == null)
            {
                return NotFound();
            }
            return Ok(shelf);
        }

        [HttpPost("add-shelf")]
        public IActionResult InsertShelf(ShelfModel shelfModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _shelfService.InsertShelfForUser(shelfModel);
            return Ok();
        }

        [HttpPut("update-shelf-by-id/{id}")]
        public IActionResult EditShelf(string id, ShelfModel shelfModel)
        {
            var shelf = _shelfService.GetShelfById(id);
            if (shelf == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _shelfService.EditShelf(id, shelfModel);
            return Ok();
        }

        [HttpDelete("delete-shelf-by-id/{id}")]
        public IActionResult RemoveShelf(string id)
        {
            var shelf = _shelfService.GetShelfById(id);
            if (shelf == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _shelfService.RemoveShelf(id);
            return Ok();
        }

        [HttpGet("get-books-of-shelf/id")]
        public IActionResult GetBooksOfShelf(string id)
        {
            var shelf = _shelfService.GetShelfById(id);
            if (shelf == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var shelfWithBooks = _book_ShelfService.GetShelfWithBooksByShelfId(id);
            return Ok(shelfWithBooks);
        }
    }
}
