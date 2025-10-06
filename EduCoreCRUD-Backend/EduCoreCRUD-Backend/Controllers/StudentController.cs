using EduCoreCRUD_Backend.Models;
using EduCoreCRUD_Backend.Models.Data;
using EduCoreCRUD_Backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduCoreCRUD_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly EduCoreDBContext dbContext;
        public StudentController(EduCoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]

        public IActionResult GetAllStudents()
        {
            var allStudents = dbContext.student.ToList();
            dbContext.SaveChanges();
            return Ok(allStudents);
        }

        [HttpGet]
        [Route("{Id:guid}")]

        public IActionResult GetStudentById(Guid Id)
        {
            var student = dbContext.student.Find(Id);
            if (student == null)
            {
                return NotFound("Student not found");
            }
            dbContext.SaveChanges();
            return Ok(student);

        }

        [HttpPost]
        public IActionResult AddStudent(AddStudentDto addStudentDto)
        {
            var student = new Student()
            {

                Name = addStudentDto.Name,
                Surname = addStudentDto.Surname,
                Gender = addStudentDto.Gender,
                DateOfBirth = addStudentDto.DateOfBirth,
                HomeAddress = addStudentDto.HomeAddress,
                Email = addStudentDto.Email,
                PhoneNumber = addStudentDto.PhoneNumber,

            };
            dbContext.student.Add(student);
            dbContext.SaveChanges();
            return Ok(student);


        }

        [HttpPut]
        public IActionResult UpdateStudent(Guid Id, UpdateStudentDto updateStudentDto)
        {
            var student = dbContext.student.Find(Id);
            if (student == null)
            {
                return NotFound("Admin not found");
            }
            student.Name = updateStudentDto.Name;
            student.Surname = updateStudentDto.Surname;
            student.Gender = updateStudentDto.Gender;
            student.DateOfBirth = updateStudentDto.DateOfBirth;
            student.HomeAddress = updateStudentDto.HomeAddress;
            student.Email = updateStudentDto.Email;
            student.PhoneNumber = updateStudentDto.PhoneNumber;

            dbContext.SaveChanges();
            return Ok(student);

        }
        [HttpDelete]
        [Route("{Id:guid}")]
        public IActionResult DeleteStudent(Guid Id)
        {
            var student = dbContext.student.Find(Id);
            if (student == null)
            {
                return NotFound("Admin not found");
            }
            dbContext.student.Remove(student);
            dbContext.SaveChanges();
            return Ok(student);

        }

    }
}
