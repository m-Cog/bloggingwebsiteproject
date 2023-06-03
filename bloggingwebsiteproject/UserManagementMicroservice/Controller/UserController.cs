
using bloggingwebsiteproject.UserManagementManagement.Business_Layer.ModelDto;
using bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.ModelDto;
using bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace bloggingwebsiteproject.UserManagementMicroservice.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService,IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        
        [HttpGet]
        [EnableCors("AllowLocalhost")]
        public IActionResult Index()
        {
           var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        [EnableCors("AllowLocalhost")]
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
        [EnableCors("AllowLocalhost")]
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
        [EnableCors("AllowLocalhost")]
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
        [EnableCors("AllowLocalhost")]
        public IActionResult DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
            return NoContent();
        }
        [HttpPost("signup")]
        [EnableCors("AllowLocalhost")]
        public IActionResult Signup(AuthUserDto authUserDto)
        {
            try
            {
                _userService.Signup(authUserDto);
                return Ok(authUserDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPost("login")]
        [EnableCors("AllowLocalhost")]
        public IActionResult Login([FromBody] LoginReq loginRequest)
        {
            try
            {
                var user = _userService.Login(loginRequest);



                // Generate JWT Token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                              new Claim(ClaimTypes.Name, user.Username),
                              new Claim(ClaimTypes.Email, user.Email),
                              new Claim(ClaimTypes.Role,user.Role.ToString())
 }),
                    Expires = DateTime.UtcNow.AddHours(_configuration.GetValue<int>("Jwt:ExpiryInHours")),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);



                // Return JWT token
                return Ok(new { Token = tokenString });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
