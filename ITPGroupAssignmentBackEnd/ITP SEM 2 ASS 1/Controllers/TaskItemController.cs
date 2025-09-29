using ITP_SEM_2_ASS_1.Models;
using ITP_SEM_2_ASS_1.Models.Data;
using ITP_SEM_2_ASS_1.Models.Entitties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITP_SEM_2_ASS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly applicationDbContext dbContext;
        public TaskItemController(applicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var allTasks = dbContext.TaskItems.ToList();
            dbContext.SaveChanges();
            return Ok(allTasks);
        }

        [HttpGet]
        [Route("{TaskItemId:Guid}")]
        public IActionResult GetTaskById(Guid TaskItemId)
        {
            var TaskItem = dbContext.TaskItems.Find(TaskItemId);
            if (TaskItem == null)
            {
                return NotFound();
            }

            dbContext.SaveChanges();
            return Ok(TaskItem);
        }

        [HttpPost]
        public IActionResult AddItem(addTaskItemDto addTaskItemDto)
        {
            var TaskItemEntity = new TaskItem() 
            {

                Name = addTaskItemDto.Name,
                dueDate = addTaskItemDto.dueDate

            };
            dbContext.TaskItems.Add(TaskItemEntity);
            dbContext.SaveChanges();
            return Ok(TaskItemEntity);
        }

        [HttpDelete]
        [Route ("{TaskItemId:guid}")]
        public IActionResult DeleteItem(Guid TaskItemId)
        {
            var item = dbContext.TaskItems.Find(TaskItemId);
            if (item == null)
            {
                return NotFound();
            }

            dbContext.TaskItems.Remove(item);
            dbContext.SaveChanges();
            return Ok(item);
        }

        [HttpPut]
        [Route("{TaskItemId:guid}")]
        public IActionResult updateItems(Guid TaskItemId, addTaskItemDto addTaskDto)
        {
            var item = dbContext.TaskItems.Find(TaskItemId);
            if (item == null)
                return NotFound();
            item.Name = addTaskDto.Name;
            item.dueDate = addTaskDto.dueDate;
            dbContext.SaveChanges();
            return Ok(item);
        }
    }
}
