namespace EduCoreCRUD_Backend.Models.Entities
{
    public class Admin
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Gender { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required string HomeAddress { get; set; }

        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Module> Modules { get; set; } = new List<Module>();

    }
}
