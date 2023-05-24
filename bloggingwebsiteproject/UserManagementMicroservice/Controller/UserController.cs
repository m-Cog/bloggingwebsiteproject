using bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.ModelDto;
using bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace bloggingwebsiteproject.UserManagementMicroservice.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var user = _userService.GetUserId(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _userService.CreateUser(createUserDto);
            return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _userService.UpdateUser(userId, updateUserDto);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
            return NoContent();
        }
    }
}
