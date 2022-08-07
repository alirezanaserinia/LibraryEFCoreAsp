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
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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

        [HttpPost("add-user")]
        public IActionResult InsertUser(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _userService.InsertUser(userModel);
            return Ok();
        }

        [HttpPut("update-user-by-id/{id}")]
        public IActionResult EditUser(string id, UserModel userModel)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _userService.EditUser(id, userModel);
            return Ok();
        }

        [HttpDelete("delete-user-by-id/{id}")]
        public IActionResult RemoveUser(string id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _userService.RemoveUser(id);
            return Ok();
        }


        [HttpGet("get-shelfs-of-user/id")]
        public IActionResult GetShelfsOfUser(string id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userWithShelfs = _userService.GetUserWithShelfsByUserId(id);
            return Ok(userWithShelfs);
        }

    }
}
