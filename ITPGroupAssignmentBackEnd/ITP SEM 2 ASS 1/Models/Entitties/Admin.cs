using System.ComponentModel.DataAnnotations.Schema;

namespace ITP_SEM_2_ASS_1.Models.Entitties
{
    public class Admin
    {
        public Guid AdminId { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string gender { get; set; }
        public required DateOnly dateOfBirth { get; set; }
        public required string homeAdress { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        //public int ApplicationUserId { get; set; }
       
        [ForeignKey(nameof(user))]   // tells EF this is the FK to ApplicationUser
        public int ApplicationUserId { get; set; }
        public ApplicationUser user { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Module> Modules { get; set; } = new List<Module>();


      
    }
}
