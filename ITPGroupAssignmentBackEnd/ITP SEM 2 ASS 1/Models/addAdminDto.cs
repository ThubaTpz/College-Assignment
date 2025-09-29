namespace ITP_SEM_2_ASS_1.Models
{
    public class AddAdminDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string gender { get; set; }
        public required DateOnly dateOfBirth { get; set; }
        public required string homeAdress { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
    }
}