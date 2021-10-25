using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password must be complex")]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
    }
}

// (?=.* Any Character \\d One of them has to be number)
// (?=.*[a-z] Any character that is lowercase)
// (?=.*[A-Z] Any character that is uppercase lowercase)
// .{4,8}$ Has to be 4-8 characters long