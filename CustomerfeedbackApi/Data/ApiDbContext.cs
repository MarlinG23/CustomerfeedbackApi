using CustomerfeedbackApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerfeedbackApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<Users> users { get; set; } //standard user infor
        public DbSet<UserInfo> UserInfo { get; set; }//Security for passwords etc
    }
}
