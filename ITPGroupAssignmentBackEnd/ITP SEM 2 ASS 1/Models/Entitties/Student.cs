namespace ITP_SEM_2_ASS_1.Models.Entitties
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public required string  Name { get; set; }
        public required string Surname { get; set; }
        public required string gender { get; set; }
        public required DateOnly dateOfBirth { get; set; }
        public required string homeAdress { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }

        //FK for ApplicationUser
        public string ApplicationUserId { get; set; }
        public ApplicationUser user { get; set; }
        public ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
