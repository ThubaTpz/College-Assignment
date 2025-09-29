using ITP_SEM_2_ASS_1.Models;
using ITP_SEM_2_ASS_1.Models.Data;
using ITP_SEM_2_ASS_1.Models.Entitties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITP_SEM_2_ASS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly applicationDbContext dbContext;
        public AdminController(applicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            var allAdmins = dbContext.Admins.ToList();
            dbContext.SaveChanges();
            return Ok(allAdmins);
        }

        [HttpGet]
        [Route("{AdminId:Guid}")]
        public IActionResult GetAdminById(Guid AdminId)
        {
            var Admin = dbContext.Admins.Find(AdminId);
            if (Admin == null)
            {
                return NotFound();
            }

            dbContext.SaveChanges();
            return Ok(Admin);
        }

        [HttpPost]
        public IActionResult AddAdmin(AddAdminDto addAdminDto)
        {
            var Admin = new Admin()
            {
                Name = addAdminDto.Name,
                Surname = addAdminDto.Surname,
                gender = addAdminDto.gender,
                dateOfBirth = addAdminDto.dateOfBirth,
                homeAdress = addAdminDto.homeAdress,
                Email = addAdminDto.Email,
                Phone = addAdminDto.Phone
            };

            dbContext.Admins.Add(Admin);
            dbContext.SaveChanges();
            return Ok(Admin);
        }

        [HttpDelete]
        [Route("{AdminId:guid}")]
        public IActionResult DeleteAdmin(Guid AdminId)
        {
            var admin = dbContext.Admins.Find(AdminId);
            if (admin == null)
            {
                return NotFound();
            }

            dbContext.Admins.Remove(admin);
            dbContext.SaveChanges();
            return Ok(admin);
        }

        [HttpPut]
        [Route("{AdminId:guid}")]
        public IActionResult updateAdmin(Guid AdminId, AddAdminDto addAdminDto)
        {
            var Admin = dbContext.Admins.Find(AdminId);

            if (Admin == null)
                return NotFound();

            Admin.Name = addAdminDto.Name;
            Admin.Surname = addAdminDto.Surname;
            Admin.gender = addAdminDto.gender;
            Admin.dateOfBirth = addAdminDto.dateOfBirth;
            Admin.homeAdress = addAdminDto.homeAdress;
            Admin.Email = addAdminDto.Email;
            Admin.Phone = addAdminDto.Phone;
            dbContext.SaveChanges();
            return Ok(Admin);
        }
    }
}
