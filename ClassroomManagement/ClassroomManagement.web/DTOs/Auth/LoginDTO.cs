using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClassroomManagement.web.DTOs.Auth
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;
    }
}
