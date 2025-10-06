using EduCoreCRUD_Backend.Models;
using EduCoreCRUD_Backend.Models.Data;
using EduCoreCRUD_Backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduCoreCRUD_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly EduCoreDBContext dbContext;
        public CourseController(EduCoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]

        public IActionResult GetAllCourses()
        {
            var allCourses = dbContext.course.ToList();
            dbContext.SaveChanges();
            return Ok(allCourses);
        }

        [HttpGet]
        [Route("{Id:guid}")]

        public IActionResult GetCourseById(Guid Id)
        {
            var Course = dbContext.course.Find(Id);
            if (Course == null)
            {
                return NotFound("Course not found");
            }
            dbContext.SaveChanges();
            return Ok(Course);

        }

        [HttpPost]
        public IActionResult AddCourse(AddCourseDto addCourseDto)
        {
            var course = new Course()
            {

                Name = addCourseDto.Name,
                Duration = addCourseDto.Duration,
                

            };
            dbContext.course.Add(course);
            dbContext.SaveChanges();
            return Ok(course);


        }
        [HttpPut]
        public IActionResult UpdateCourse(Guid Id, UpdateCourseDto updateCourseDto)
        {
            var course = dbContext.course.Find(Id);
            if (course == null)
            {
                return NotFound("Admin not found");
            }
            course.Name = updateCourseDto.Name;
            course.Duration = updateCourseDto.Duration;
            

            dbContext.SaveChanges();
            return Ok(course);

        }
        [HttpDelete]
        [Route("{Id:guid}")]
        public IActionResult DeleteCourse(Guid Id)
        {
            var course = dbContext.course.Find(Id);
            if (course == null)
            {
                return NotFound("Admin not found");
            }
            dbContext.course.Remove(course);
            dbContext.SaveChanges();
            return Ok(course);

        }

    }
}
