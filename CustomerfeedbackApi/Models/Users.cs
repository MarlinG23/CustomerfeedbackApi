using System.ComponentModel.DataAnnotations;

namespace CustomerfeedbackApi.Models
{
    public class Users
    {
        [Key] // Primary key
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string Customerfeedback { get; set; } = "";
    }
}
