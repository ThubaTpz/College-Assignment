namespace EduCoreCRUD_Backend.Models.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string DueDate { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
    }
}
