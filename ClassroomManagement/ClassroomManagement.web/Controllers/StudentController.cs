using ClassroomManagement.web.DTOs.Student;
using ClassroomManagement.web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomManagement.web.Infrstructure;

namespace ClassroomManagement.web.Controllers
{
    /// <summary>
    /// Controller to create, get, edit and delete data in/from the database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _iStudentService;

        public StudentController(IStudentService studentService)
        {
            _iStudentService = studentService;
        }
        /// <summary>
        /// Tab to save student details into the database
        /// </summary>
        [Authorize(Roles = "Teacher")]
        [HttpPost("AddStudent")]
        public async Task<string> PostStudent(CreateStudentDTO _newStudnet)
        {
            return await _iStudentService.AddStudent(_newStudnet);
        }
        /// <summary>
        /// Tab to get details of all students
        /// </summary>
        [Authorize(Roles = "Student,Teacher")]
        [HttpGet("GetAllStudent")]
        public ActionResult<List<GetStudentDTO>> GetAllStudents()
        {
            return Ok(_iStudentService.FetchStudentsList());
        }
        /// <summary>
        /// Tab to get details of single student
        /// </summary>
        [Authorize(Roles = "Student,Teacher")]
        [HttpGet("GetSingleStudent")]
        public ActionResult<GetStudentDTO> GetSingleStudent(int id)
        {
            return Ok(_iStudentService.FetchSingleStudent(id));
        }
        /// <summary>
        /// Tab to edit details of student
        /// </summary>
        [Authorize(Roles = "Teacher")]
        [HttpPut("EditStudent")]
        public async Task<string> PutStudent(UpdateStudentDTO _student)
        {
            return await _iStudentService.UpdateStudent(_student);
        }
        /// <summary>
        /// Tab to edit score of student
        /// </summary>
        [Authorize(Roles = "Teacher")]
        [HttpPut("EditScore")]
        public async Task<string> PutStudnetScore(int Id, int Score)
        {
            return await _iStudentService.UpdateScore(Id, Score);
        }
        /// <summary>
        /// Tab to delete details of student
        /// </summary>
        [Authorize(Roles = "Teacher")]
        [HttpDelete("DeleteStudent")]
        public async Task<string> DeleteStudent(int Id)
        {
            return await _iStudentService.DeleteStudent(Id);
        }
    }
}
