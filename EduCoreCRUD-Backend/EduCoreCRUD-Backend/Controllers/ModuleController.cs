using EduCoreCRUD_Backend.Models;
using EduCoreCRUD_Backend.Models.Data;
using EduCoreCRUD_Backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduCoreCRUD_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly EduCoreDBContext dbContext;
        public ModuleController(EduCoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]

        public IActionResult GetAllModules()
        {
            var allModules = dbContext.module.ToList();
            dbContext.SaveChanges();
            return Ok(allModules);
        }

        [HttpGet]
        [Route("{Id:guid}")]

        public IActionResult GetModuleById(Guid Id)
        {
            var module = dbContext.module.Find(Id);
            if (module == null)
            {
                return NotFound("Module not found");
            }
            dbContext.SaveChanges();
            return Ok(module);

        }

        [HttpPost]
        public IActionResult AddModule(AddModuleDto addModuleDto)
        {
            var module = new Module()
            {

                Name = addModuleDto.Name,
                Credits = addModuleDto.Credits,
                ModuleCode = addModuleDto.ModuleCode,
                

            };
            dbContext.module.Add(module);
            dbContext.SaveChanges();
            return Ok(module);


        }

        [HttpPut]
        public IActionResult UpdateModule(Guid Id, UpdateModuleDto updateModuleDto)
        {
            var module = dbContext.module.Find(Id);
            if (module == null)
            {
                return NotFound("Module not found");
            }
            module.Name = updateModuleDto.Name;
            module.Credits = updateModuleDto.Credits;
            module.ModuleCode = updateModuleDto.ModuleCode;

            dbContext.SaveChanges();
            return Ok(module);

        }
        [HttpDelete]
        [Route("{Id:guid}")]
        public IActionResult DeleteModule(Guid Id)
        {
            var module = dbContext.module.Find(Id);
            if (module == null)
            {
                return NotFound("Module not found");
            }
            dbContext.module.Remove(module);
            dbContext.SaveChanges();
            return Ok(module);

        }



    }
}
