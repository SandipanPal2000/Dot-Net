using ClassroomManagement.web.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassroomManagement.web.Infrstructure
{
    public class DbObject : DbContext
    {
        public DbObject(DbContextOptions<DbObject> options): base(options)
        {

        }
        public DbSet<StudentInfo> StudentTB { get; set; }
        public DbSet<User> UserTB { get; set; }
    }
}
