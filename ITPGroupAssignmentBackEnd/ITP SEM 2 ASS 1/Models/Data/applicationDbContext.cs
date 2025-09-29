using ITP_SEM_2_ASS_1.Models.Entitties;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ITP_SEM_2_ASS_1.Models.Data
{
    public class applicationDbContext :IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public applicationDbContext(DbContextOptions<applicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecturer> lecturers { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
