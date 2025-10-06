using EduCoreCRUD_Backend.Models;
using EduCoreCRUD_Backend.Models.Data;
using EduCoreCRUD_Backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduCoreCRUD_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly EduCoreDBContext dbContext;
        public TaskItemController(EduCoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]

        public IActionResult GetAllTaskItems()
        {
            var allTaskItems = dbContext.taskItem.ToList();
            dbContext.SaveChanges();
            return Ok(allTaskItems);
        }

        [HttpGet]
        [Route("{Id:guid}")]

        public IActionResult GetTaskItemById(Guid Id)
        {
            var taskItem = dbContext.taskItem.Find(Id);
            if (taskItem == null)
            {
                return NotFound("Task Item not found");
            }
            dbContext.SaveChanges();
            return Ok(taskItem);

        }

        [HttpPost]
        public IActionResult AddTaskItem(AddTaskItemDto addTaskItemDto)
        {
            var taskItem = new TaskItem()
            {

                Name = addTaskItemDto.Name,
                DueDate = addTaskItemDto.DueDate
                


            };
            dbContext.taskItem.Add(taskItem);
            dbContext.SaveChanges();
            return Ok(taskItem);


        }

        [HttpPut]
        public IActionResult UpdateTaskItem(Guid Id, UpdateTaskItemDto updateTaskItemDto)
        {
            var taskItem = dbContext.taskItem.Find(Id);
            if (taskItem == null)
            {
                return NotFound("Task Item not found");
            }
            taskItem.Name = updateTaskItemDto.Name;
            taskItem.DueDate = updateTaskItemDto.DueDate;
          

            dbContext.SaveChanges();
            return Ok(taskItem);

        }
        [HttpDelete]
        [Route("{Id:guid}")]
        public IActionResult DeleteTaskItem(Guid Id)
        {
            var taskItem = dbContext.taskItem.Find(Id);
            if (taskItem == null)
            {
                return NotFound("Task Item not found");
            }
            dbContext.taskItem.Remove(taskItem);
            dbContext.SaveChanges();
            return Ok(taskItem);

        }
    }
}
