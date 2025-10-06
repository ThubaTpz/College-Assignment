namespace EduCoreCRUD_Backend.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Gender { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required string HomeAddress { get; set; }

        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
