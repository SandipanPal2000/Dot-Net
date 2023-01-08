using System.ComponentModel.DataAnnotations;

namespace ClassroomManagement.web.DTOs.Student
{
    public class UpdateStudentDTO
    {
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; } = string.Empty;
        [Required]
        public string Department { get; set; } = string.Empty;
        [Required]
        public int Score { get; set; }
    }
}
