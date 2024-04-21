using System.ComponentModel.DataAnnotations;

namespace CustomerfeedbackApi.Models
{
    public class UserInfo
    {
        [Key] // Primary key
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

    }
}
