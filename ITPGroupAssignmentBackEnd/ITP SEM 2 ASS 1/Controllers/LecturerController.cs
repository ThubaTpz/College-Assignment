using ITP_SEM_2_ASS_1.Models;
using ITP_SEM_2_ASS_1.Models.Data;
using ITP_SEM_2_ASS_1.Models.Entitties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITP_SEM_2_ASS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly applicationDbContext dbContext;
        public LecturerController(applicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllLecturers()
        {
            var allLecturer = dbContext.lecturers.ToList();
            dbContext.SaveChanges();
            return Ok(allLecturer);
        }

        [HttpGet]
        [Route("{LecturerId:Guid}")]
        public IActionResult GetLecturerById(Guid LecturerId)
        {
            var Lecturer = dbContext.lecturers.Find(LecturerId);
            if (Lecturer == null)
            {
                return NotFound();
            }

            dbContext.SaveChanges();
            return Ok(Lecturer);
        }

        [HttpPost]
        public IActionResult AddLecturer(addLecturerDto addLecturerDto)
        {
            var lect = new Lecturer()
            {
                Name = addLecturerDto.Name,
                Surname = addLecturerDto.Surname,
                gender = addLecturerDto.gender,
                dateOfBirth = addLecturerDto.dateOfBirth,
                homeAdress = addLecturerDto.homeAdress,
                Email = addLecturerDto.Email,
                Phone = addLecturerDto.Phone
            };

            dbContext.lecturers.Add(lect);
            dbContext.SaveChanges();
            return Ok(lect);
        }

        [HttpDelete]
        [Route("{LecturerId:guid}")]
        public IActionResult DeleteLecturer(Guid LecturerId)
        {
            var lecturer = dbContext.lecturers.Find(LecturerId);
            if (lecturer == null)
            {
                return NotFound();
            }

            dbContext.lecturers.Remove(lecturer);
            dbContext.SaveChanges();
            return Ok(lecturer);
        }

        [HttpPut]
        [Route("{LecturerId:guid}")]
        public IActionResult updateAdmin(Guid LecturerId, addLecturerDto addLecturerDto)
        {
            var lecturer = dbContext.lecturers.Find(LecturerId);

            if (lecturer == null)
                return NotFound();

            lecturer.Name = addLecturerDto.Name;
            lecturer.Surname = addLecturerDto.Surname;
            lecturer.gender = addLecturerDto.gender;
            lecturer.dateOfBirth = addLecturerDto.dateOfBirth;
            lecturer.homeAdress = addLecturerDto.homeAdress;
            lecturer.Email = addLecturerDto.Email;
            lecturer.Phone = addLecturerDto.Phone;
            dbContext.SaveChanges();
            return Ok(lecturer);
        }
    }
}
