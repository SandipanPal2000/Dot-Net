using ClassroomManagement.web.Infrstructure;
using ClassroomManagement.web.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ClassroomManagement.web.Services
{
    public interface IAuthServices
    {
        Task<ServiceResponse<string>> Login(string Email, string Password);
        Task<ServiceResponse<int>> Register(User user, string Password);
    }
}
