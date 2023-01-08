using ClassroomManagement.web.Infrstructure.Roles;
using System.ComponentModel.DataAnnotations;

namespace ClassroomManagement.web.Models
{
    public class StudentInfo
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set;} = string.Empty;
        [Required]
        public string Department { get; set; } = string.Empty;
        [Required]
        public int Score { get; set; }
    }
}
