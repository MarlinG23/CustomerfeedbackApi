using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerfeedbackApi.Models;
using CustomerfeedbackApi.Data;
using CustomerfeedbackApi.Services;

namespace CustomerfeedbackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly EmailService _emailService; // Added EmailService

        public UsersController(ApiDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService; // Initialized EmailService
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Getusers()
        {
            return await _context.users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _context.users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.UserId)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            _context.users.Add(users);
            await _context.SaveChangesAsync();

            // Send email with the feedback comment
            SendFeedbackEmail(users.Email, users);

            return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
        }

        private void SendFeedbackEmail(string fromAddress, Users users)
        {
           
            var toAddress = "marling.theaiguy@gmail.com";//Points to the directed email address
            var subject = "New Feedback Submitted";
            var body = $"Name: {users.Name}\nEmail: {users.Email}\nFeedback: {users.Customerfeedback}";

            _emailService.SendFeedbackEmail(fromAddress, toAddress, subject, body);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var users = await _context.users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return _context.users.Any(e => e.UserId == id);
        }
    }
}
