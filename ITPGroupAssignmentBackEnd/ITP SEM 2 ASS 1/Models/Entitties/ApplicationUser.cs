using Microsoft.AspNetCore.Identity;



namespace ITP_SEM_2_ASS_1.Models.Entitties
{
    public class ApplicationUser : IdentityUser <int>// Identify if user exists login
    {

        public  Guid ApplicationUserId { get;set; }
        //public required string Email {  get; set; }
        //public required string Password { get; set; }
        //public required string PasswordHash {get;set; }

        public Student StudentProfile { get; set; }
        public Lecturer LecturerProfile { get; set; }
        public Admin AdminProfile { get; set; }
        public Guid ApplicationRoleId { get; set; } //FK of the role
        public ApplicationRole Role { get; set; } // navigation property to represent the manager
        //relationship 1 to many ( 1 role belong to many users , a user can belong to 1 role)

       


    }
}
