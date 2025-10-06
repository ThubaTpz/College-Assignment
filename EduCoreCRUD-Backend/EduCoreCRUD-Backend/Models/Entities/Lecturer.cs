namespace EduCoreCRUD_Backend.Models.Entities
{
    public class Lecturer
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Gender { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required string HomeAddress { get; set; }

        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Module> Modules { get; set; } = new List<Module>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
