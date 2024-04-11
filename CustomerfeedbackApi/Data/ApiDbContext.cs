using CustomerfeedbackApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerfeedbackApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<Users> users { get; set; }
    }
}
