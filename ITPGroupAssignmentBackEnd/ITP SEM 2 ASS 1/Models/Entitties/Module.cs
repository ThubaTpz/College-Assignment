namespace ITP_SEM_2_ASS_1.Models.Entitties
{
    public class Module
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int credits { get; set; }
        public required string moduleCode { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();


    }
}
