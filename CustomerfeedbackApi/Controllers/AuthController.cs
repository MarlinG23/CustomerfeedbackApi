//using CustomerfeedbackApi.Data;
//using CustomerfeedbackApi.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;
//using BCrypt.Net;

//namespace CustomerfeedbackApi.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly ApiDbContext _context;

//        public AuthController(ApiDbContext context)
//        {
//            _context = context;
//        }

//        [HttpPost]
//        [Route("register")]
//        public IActionResult Register([FromBody] RegisterRequest request)
//        {
//            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
//            var newUser = new UserInfo
//            {
//                Username = request.Username,
//                PasswordHash = hashedPassword
//            };
//            _context.UserInfo.Add(newUser);
//            _context.SaveChanges();
//            return Ok(new { message = "User registered successfully" });
//        }

//        [HttpGet("{username}")]
//        public IActionResult GetUser(string username)
//        {
//            var user = _context.UserInfo.FirstOrDefault(u => u.Username == username);
//            if (user != null)
//            {
//                return Ok(user);
//            }
//            else
//            {
//                return NotFound();
//            }
//        }


//        [HttpPost]
//        [Route("login")]
//        public IActionResult Login([FromBody] LoginRequest request)
//        {
//            var user = _context.UserInfo.FirstOrDefault(u => u.Username == request.Username);
//            if (user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
//            {
//                return Ok(new { message = "Login successful" });
//            }
//            else
//            {
//                return BadRequest(new { message = "Invalid username or password" });
//            }
//        }
//    }

//    public class RegisterRequest
//    {
//        public string Username { get; set; }
//        public string Password { get; set; }
//    }

//    public class LoginRequest
//    {
//        public string Username { get; set; }
//        public string Password { get; set; }
//    }
//}
