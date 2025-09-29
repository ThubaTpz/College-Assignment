namespace ITP_SEM_2_ASS_1.Models.Entitties
{
    public class Course
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Duration { get; set; }

        public ICollection<Lecturer> Lectures { get; set; } = new List<Lecturer>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Module> modules { get; set; } = new List<Module>();
    }
}
