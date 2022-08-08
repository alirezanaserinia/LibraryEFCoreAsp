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
    }
}
