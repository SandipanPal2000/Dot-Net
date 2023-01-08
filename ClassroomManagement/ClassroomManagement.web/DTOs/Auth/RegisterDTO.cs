using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClassroomManagement.web.DTOs.Auth
{
    public class RegisterDTO
    {
        [Required]
        [RegularExpression(@"^[A-Za-z][A-Za-z ]*[A-Za-z]$", ErrorMessage = "Only Alphabets and space allowed")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;

    }
}
