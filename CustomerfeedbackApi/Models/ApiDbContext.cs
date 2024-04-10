using Microsoft.EntityFrameworkCore;

namespace CustomerfeedbackApi.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions option) : base(option) 
        {
        
        }
        public DbSet<Users>users { get; set; }
    }
}
