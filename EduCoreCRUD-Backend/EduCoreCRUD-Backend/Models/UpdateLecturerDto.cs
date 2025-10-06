namespace EduCoreCRUD_Backend.Models
{
    public class UpdateLecturerDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Gender { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required string HomeAddress { get; set; }

        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
