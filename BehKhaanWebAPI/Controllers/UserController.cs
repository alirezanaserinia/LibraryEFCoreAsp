using BehKhaan.Application.Interfaces;
using BehKhaan.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BehKhaanWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IModelValidator _validator;
        private readonly IUserService _userService;

        public UserController(IModelValidator validator, IUserService userService)
        {
            _userService = userService;
            _validator = validator;
        }

        [HttpGet("get-all-users")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("get-user-by-id/{userId}")]
        public IActionResult GetUserById(string userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("insert-user")]
        public IActionResult InsertUser(UserModel userModel)
        {
            var validateResult = _validator.CheckUserNameUniqueness(userModel.UserName);
            if (!validateResult.Success)
            {
                return BadRequest(validateResult.Message);
            }
            _userService.InsertUser(userModel);
            return Ok();
        }

        [HttpPut("update-user-by-id/{userId}")]
        public IActionResult EditUser(string userId, UserModel userModel)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            var validateResult = _validator.CheckUserNameUniqueness(userModel.UserName);
            if (!validateResult.Success)
            {
                return BadRequest(validateResult.Message);
            }
            _userService.EditUser(userId, userModel);
            return Ok();
        }

        [HttpDelete("delete-user-by-id/{userId}")]
        public IActionResult RemoveUser(string userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            _userService.RemoveUser(userId);
            return Ok();
        }


        [HttpGet("get-shelfs-of-user/userId")]
        public IActionResult GetShelfsOfUser(string userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            var userWithShelfs = _userService.GetUserWithShelfsByUserId(userId);
            return Ok(userWithShelfs);
        }

        [HttpGet("get-number-of-books-for-users")]
        public IActionResult GetNumOfBooksForUsers()
        {
            var usersWithNumOfBooks = _userService.GetNumOfBooksForUsers();
            if (usersWithNumOfBooks == null)
            {
                return NotFound();
            }
            return Ok(usersWithNumOfBooks);
        }

        [HttpGet("get-number-of-read-books-for-users")]
        public IActionResult GetNumOfReadBooksForUsers()
        {
            var usersWithNumOfReadBooks = _userService.GetNumOfReadBooksForUsers();
            if (usersWithNumOfReadBooks == null)
            {
                return NotFound();
            }
            return Ok(usersWithNumOfReadBooks);
        }

        [HttpGet("get-users-study-state")]
        public IActionResult GetUsersStudyState()
        {
            var usersStudyState = _userService.GetUsersStudyState();
            if (usersStudyState == null)
            {
                return NotFound();
            }
            return Ok(usersStudyState);
        }

        [HttpGet("get-users-have-at-least-one-reading-book")]
        public IActionResult UsersHaveAtLeastOneReadingBook()
        {
            var usersHaveAtLeastOneReadingBook = _userService.GetUsersHaveAtLeastOneReadingBook();
            if (usersHaveAtLeastOneReadingBook == null)
            {
                return NotFound();
            }
            return Ok(usersHaveAtLeastOneReadingBook);
        }

        [HttpGet("get-ordred-list-of-users-based-on-books-read")]
        public IActionResult GetOrderedListOfUsersBasedOnBooksRead()
        {
            var orderedListOfUsers = _userService.GetOrderedListOfUsersBasedOnBooksRead();
            if (orderedListOfUsers == null)
            {
                return NotFound();
            }
            return Ok(orderedListOfUsers);
        }
    }
}
