using Microsoft.AspNetCore.Mvc;
using NewsFeedSystem.Models;
using NewsFeedSystem.Services;

namespace NewsFeedSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var userList = _userService.GetAllUser();
            return Ok(userList);
        }
        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int ID)
        {
            var userList = _userService.GetUserById(ID);
            return Ok(userList);
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser(Users users)
        {
            var instertedID = _userService.AddUser(users);

            return Ok(instertedID);
        }
        [HttpPost("EditUser")]
        public IActionResult EditUser(Users users)
        {
            var updatedID = _userService.EditUser(users);
            return Ok(updatedID);
        }

    }
}
