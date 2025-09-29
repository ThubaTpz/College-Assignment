namespace ITP_SEM_2_ASS_1.Models.Entitties
{
    public class Lecturer
    {
        public Guid LecturerId { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string gender { get; set; }
        public required DateOnly dateOfBirth { get; set; }
        public required string homeAdress { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser user { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Module> Modules { get; set; } = new List<Module>();
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
