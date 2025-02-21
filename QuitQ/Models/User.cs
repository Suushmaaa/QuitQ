using System.ComponentModel.DataAnnotations;

namespace QuitQ.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public required string Name { get; set; }
        [Required, EmailAddress]
        public required  string Email { get; set; }
        [Required]
        public required  string PasswordHash { get; set; }
        public string Role { get; set; } = "Customer"; 
    }
}
