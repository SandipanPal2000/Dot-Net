using ClassroomManagement.web.Infrstructure.Roles;
using System.ComponentModel.DataAnnotations;

namespace ClassroomManagement.web.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public AppRoles Role { get; set; } = AppRoles.Student;
    }
}
