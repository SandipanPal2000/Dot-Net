using AutoMapper;
using ClassroomManagement.web.DTOs.Student;
using ClassroomManagement.web.Models;

namespace ClassroomManagement.web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentInfo, GetStudentDTO>();
            CreateMap<CreateStudentDTO, StudentInfo>();
        }
    }
}
