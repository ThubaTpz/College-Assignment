using ITP_SEM_2_ASS_1.Models;
using ITP_SEM_2_ASS_1.Models.Data;
using ITP_SEM_2_ASS_1.Models.Entitties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;

namespace ITP_SEM_2_ASS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly applicationDbContext dbContext;
        public StudentController(applicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var AllStudents = dbContext.Students.ToList();
            dbContext.SaveChanges();
            return Ok(AllStudents);
        }

        [HttpGet]
        [Route("{StudentId:Guid}")]
        public IActionResult GetStudentById(Guid StudentId)
        {
            var Student = dbContext.TaskItems.Find(StudentId);
            if (Student == null)
            {
                return NotFound();
            }

            dbContext.SaveChanges();
            return Ok(Student);
        }

        [HttpPost]
        public IActionResult AddStudent(addStudentDto addStudentDto)
        {
            var StudentEntity = new Student()
            {
                Name = addStudentDto.Name,
                Surname = addStudentDto.Surname,
                gender = addStudentDto.gender,
                dateOfBirth = addStudentDto.dateOfBirth,
                homeAdress = addStudentDto.homeAdress,
                Email = addStudentDto.Email,
                Phone = addStudentDto.Phone
            };

            dbContext.Students.Add(StudentEntity);
            dbContext.SaveChanges();
            return Ok(StudentEntity);
        }

        [HttpDelete]
        [Route("{StudentId:guid}")]
        public IActionResult DeleteStudent(Guid StudentId)
        {
            var student = dbContext.Students.Find(StudentId);
            if (student == null)
            {
                return NotFound();
            }

            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            return Ok(student);
        }

        [HttpPut]
        [Route("{StudentId:guid}")]
        public IActionResult updateStudents(Guid StudentId, addStudentDto addStudentDto)
        {
            var student = dbContext.Students.Find(StudentId);

            if (student == null)
                return NotFound();

            student.Name = addStudentDto.Name;
            student.Surname = addStudentDto.Surname;
            student.gender = addStudentDto.gender;
            student.dateOfBirth = addStudentDto.dateOfBirth;
            student.homeAdress = addStudentDto.homeAdress;
            student.Email = addStudentDto.Email;
            student.Phone = addStudentDto.Phone;
            dbContext.SaveChanges();
            return Ok(student);
        }
    }
}
