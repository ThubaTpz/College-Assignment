using ITP_SEM_2_ASS_1.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITP_SEM_2_ASS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly applicationDbContext dbContext;
        public CourseController(applicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
