using System.ComponentModel.DataAnnotations;

namespace ClassroomManagement.web.DTOs.Student
{
    public class CreateStudentDTO
    {
        public int StudentId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z][A-Za-z ]*[A-Za-z]$", ErrorMessage = "Only Alphabets and space allowed")]
        [Display(Name ="Enter Your Name")]
        public string StudentName { get; set; } = string.Empty;
        [Required]
        public string Department { get; set; } = string.Empty;
        [Required]
        [Range(0,100)]
        public int Score { get; set; }
    }
}
