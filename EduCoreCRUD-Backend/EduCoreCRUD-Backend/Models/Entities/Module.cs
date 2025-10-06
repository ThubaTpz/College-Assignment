namespace EduCoreCRUD_Backend.Models.Entities
{
    public class Module
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Credits { get; set; }
        public required string ModuleCode { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();


    }
}
