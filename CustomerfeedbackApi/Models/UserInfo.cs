using System.ComponentModel.DataAnnotations;

namespace CustomerfeedbackApi.Models
{
    public class UserInfo
    {
        [Key] // Primary key
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
        public bool IsLockedOut { get; set; } // New property to track lockout status

        public int FailedLoginAttempts { get; set; } // New property to track failed login attempts

    }
}
