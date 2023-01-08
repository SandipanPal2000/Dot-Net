using ClassroomManagement.web.DTOs.Student;
using ClassroomManagement.web.Infrstructure;

namespace ClassroomManagement.web.Services
{
    public interface IStudentService
    {
        Task<ServiceResponse<List<GetStudentDTO>>> FetchStudentsList();
        Task<ServiceResponse<GetStudentDTO>> FetchSingleStudent(int Id);
        Task<string> AddStudent(CreateStudentDTO _newStudent);
        Task<string> UpdateStudent(UpdateStudentDTO _student);
        Task<string> DeleteStudent(int Id);
        Task<string> UpdateScore(int Id, int Score);
    }
}
