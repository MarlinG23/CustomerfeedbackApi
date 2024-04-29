using CustomerfeedbackApi.Data;
using CustomerfeedbackApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BCrypt.Net;
using System;

namespace CustomerfeedbackApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public AuthController(ApiDbContext context)
        {
            _context = context;
        }

        public class RegisterRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            // Validate email address format
            if (!IsValidEmail(request.Email))
            {
                return BadRequest(new { message = "Invalid email address format" });
            }

            // Check if password starts with a capital letter and has at least 8 characters with at least 1 funny character
            if (!char.IsUpper(request.Password[0]) || request.Password.Length < 8 || !request.Password.Any(char.IsPunctuation))
            {
                return BadRequest(new { message = "Password must start with a capital letter, have at least 8 characters, and contain at least 1 funny character" });
            }

            // Hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Create new user
            var newUser = new UserInfo
            {
                Email = request.Email, // Use email address as the username
                PasswordHash = hashedPassword
            };

            // Add user to the database
            _context.UserInfo.Add(newUser);
            _context.SaveChanges();

            return Ok(new { message = "User registered successfully" });
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.UserInfo.FirstOrDefault(u => u.Email == request.Email);
            if (user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                // Reset failed login attempts on successful login
                user.FailedLoginAttempts = 0;
                _context.SaveChanges();

                return Ok(new { message = "Login successful" });
            }
            else
            {
                if (user != null)
                {
                    // Increment failed login attempts
                    user.FailedLoginAttempts++;

                    // Lock out user if they have exceeded the maximum number of failed attempts
                    if (user.FailedLoginAttempts >= 3)
                    {
                        user.IsLockedOut = true;
                    }

                    _context.SaveChanges();
                }

                return BadRequest(new { message = "Invalid email or password" });
            }
        }

    }
}
