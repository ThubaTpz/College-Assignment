namespace EduCoreCRUD_Backend.Models.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Duration { get; set; }

        public ICollection<Module> Modules { get; set; } = new List<Module>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();

    }
}
