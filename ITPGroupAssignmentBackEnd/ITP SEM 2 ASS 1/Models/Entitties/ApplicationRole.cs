
using Microsoft.AspNetCore.Identity;

namespace ITP_SEM_2_ASS_1.Models.Entitties
{
    public class ApplicationRole : IdentityRole<int> // map the user using email,pswrd to determine their role
    {
         public Guid ApplicationRoleId {get;set;}
         public required string Name { get;set;}

        public ICollection<ApplicationUser> Users {get;set;} = new List<ApplicationUser>(); // collection of users
        //relationship 1 to many ( 1 role belong to many users , a user can belong to 1 role)
    }
}
