using EduCoreCRUD_Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace EduCoreCRUD_Backend.Models.Data
{
    public class EduCoreDBContext:DbContext
    {
        public EduCoreDBContext(DbContextOptions<EduCoreDBContext> options) : base(options)
        {


        }
        public DbSet<Admin> admin { get; set; }
        public DbSet<Lecturer> lecturer { get; set; }
        public DbSet<Student> student { get; set; }
        public DbSet<Course> course { get; set; }
        public DbSet<Module> module { get; set; }
        public DbSet<TaskItem> taskItem { get; set; }



    }
}
