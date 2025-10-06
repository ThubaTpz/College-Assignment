using EduCoreCRUD_Backend.Models;
using EduCoreCRUD_Backend.Models.Data;
using EduCoreCRUD_Backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EduCoreCRUD_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly EduCoreDBContext dbContext;
        public AdminController(EduCoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]

        public IActionResult GetAllAdmins()
        {
            var allAdmins = dbContext.admin.ToList();
            dbContext.SaveChanges();
            return Ok(allAdmins);
        }

        [HttpGet]
        [Route("{Id:guid}")]

        public IActionResult GetAdminById(Guid Id)
        {
            var Admin = dbContext.admin.Find(Id);
            if (Admin == null)
            {
                return NotFound("Admin not found");
            }
            dbContext.SaveChanges();
            return Ok(Admin);

        }

        [HttpPost]
        public IActionResult AddAdmin(AddAdminDto addAdminDto)
        {
            var admin = new Admin()
            {

                Name = addAdminDto.Name,
                Surname = addAdminDto.Surname,
                Gender = addAdminDto.Gender,
                DateOfBirth = addAdminDto.DateOfBirth,
                HomeAddress = addAdminDto.HomeAddress,
                Email = addAdminDto.Email,
                PhoneNumber = addAdminDto.PhoneNumber,

            };
            dbContext.admin.Add(admin);
            dbContext.SaveChanges();
            return Ok(admin);


        }

        [HttpPut]
        public IActionResult UpdateAdmin(Guid Id, UpdateAdminDto updateAdminDto)
        {
            var admin = dbContext.admin.Find(Id);
            if (admin == null)
            {
                return NotFound("Admin not found");
            }
            admin.Name = updateAdminDto.Name;
            admin.Surname = updateAdminDto.Surname;
            admin.Gender = updateAdminDto.Gender;
            admin.DateOfBirth = updateAdminDto.DateOfBirth;
            admin.HomeAddress = updateAdminDto.HomeAddress;
            admin.Email = updateAdminDto.Email;
            admin.PhoneNumber = updateAdminDto.PhoneNumber;

            dbContext.SaveChanges();
            return Ok(admin);

        }
        [HttpDelete]
        [Route("{Id:guid}")]
        public IActionResult DeleteAdmin(Guid Id)
        {
            var admin = dbContext.admin.Find(Id);
            if(admin == null)
            {
                return NotFound("Admin not found");
            }
            dbContext.admin.Remove(admin);
            dbContext.SaveChanges();
            return Ok(admin);

        }

    }
}
