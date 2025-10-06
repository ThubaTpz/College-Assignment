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
    public class LecturerController : ControllerBase
    {
        private readonly EduCoreDBContext dbContext;
        public LecturerController(EduCoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllLecturers()
        {
            var allLecturers = dbContext.lecturer.ToList();
            dbContext.SaveChanges();
            return Ok(allLecturers);
        }

        [HttpGet]
        [Route("{Id:guid}")]

        public IActionResult GetLecturerById(Guid Id)
        {
            var Lecturer = dbContext.lecturer.Find(Id);
            if (Lecturer == null)
            {
                return NotFound("Lecturer not found");
            }
            dbContext.SaveChanges();
            return Ok(Lecturer);

        }

        [HttpPost]
        public IActionResult AddLecturer(AddLecturerDto addLecturerDto)
        {
            var lecturer = new Lecturer()
            {

                Name = addLecturerDto.Name,
                Surname = addLecturerDto.Surname,
                Gender = addLecturerDto.Gender,
                DateOfBirth = addLecturerDto.DateOfBirth,
                HomeAddress = addLecturerDto.HomeAddress,
                Email = addLecturerDto.Email,
                PhoneNumber = addLecturerDto.PhoneNumber,



            };
            dbContext.lecturer.Add(lecturer);
            dbContext.SaveChanges();
            return Ok(lecturer);


        }
        [HttpPut]
        public IActionResult UpdateLecturer(Guid Id, UpdateLecturerDto updateLecturerDto)
        {
            var lecturer = dbContext.lecturer.Find(Id);
            if (lecturer == null)
            {
                return NotFound("Lecturer not found");
            }
            lecturer.Name = updateLecturerDto.Name;
            lecturer.Surname = updateLecturerDto.Surname;
            lecturer.Gender = updateLecturerDto.Gender;
            lecturer.DateOfBirth = updateLecturerDto.DateOfBirth;
            lecturer.HomeAddress = updateLecturerDto.HomeAddress;
            lecturer.Email = updateLecturerDto.Email;
            lecturer.PhoneNumber = updateLecturerDto.PhoneNumber;



            dbContext.SaveChanges();
            return Ok(lecturer);

        }
        [HttpDelete]
        [Route("{Id:guid}")]
        public IActionResult DeleteLecturer(Guid Id)
        {
            var lecturer = dbContext.lecturer.Find(Id);
            if (lecturer == null)
            {
                return NotFound("Lecturer not found");
            }
            dbContext.lecturer.Remove(lecturer);
            dbContext.SaveChanges();
            return Ok(lecturer);

        }

    }
}
