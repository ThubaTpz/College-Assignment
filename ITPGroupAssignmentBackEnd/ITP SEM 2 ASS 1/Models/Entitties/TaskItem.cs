namespace ITP_SEM_2_ASS_1.Models.Entitties
{
    public class TaskItem
    {
        public Guid TaskItemId { get; set; }
        public required string Name { get; set; }
        public required string dueDate { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();

    }
}
