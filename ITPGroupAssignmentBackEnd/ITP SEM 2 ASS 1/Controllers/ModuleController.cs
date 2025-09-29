using ITP_SEM_2_ASS_1.Models;
using ITP_SEM_2_ASS_1.Models.Data;
using ITP_SEM_2_ASS_1.Models.Entitties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITP_SEM_2_ASS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly applicationDbContext dbContext;
        public ModuleController(applicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllModules()
        {
            var allModules = dbContext.Modules.ToList();
            dbContext.SaveChanges();
            return Ok(allModules);
        }

        [HttpGet]
        [Route("{ModuleId:Guid}")]
        public IActionResult GetModuleById(Guid ModuleId)
        {
            var Module = dbContext.Modules.Find(ModuleId);
            if (Module == null)
            {
                return NotFound();
            }

            dbContext.SaveChanges();
            return Ok(Module);
        }

        [HttpPost]
        public IActionResult AddModule(addModuleDto addModuleDto)
        {
            var module = new Module()
            {
                Name = addModuleDto.Name,
                moduleCode = addModuleDto.moduleCode,
                credits = addModuleDto.credits,
               
            };

            dbContext.Modules.Add(module);
            dbContext.SaveChanges();
            return Ok(module);
        }

        [HttpDelete]
        [Route("{ModuleId:guid}")]
        public IActionResult DeleteModule(Guid ModuleId)
        {
            var Module = dbContext.Modules.Find(ModuleId);
            if (Module == null)
            {
                return NotFound();
            }

            dbContext.Modules.Remove(Module);
            dbContext.SaveChanges();
            return Ok(Module);
        }

        [HttpPut]
        [Route("{ModuleId:guid}")]
        public IActionResult updateModule(Guid ModuleId, addModuleDto addModuleDto)
        {
            var Module = dbContext.Modules.Find(ModuleId);

            if (Module == null)
                return NotFound();

            Module.Name = addModuleDto.Name;
            Module.credits = addModuleDto.credits;
            Module.moduleCode = addModuleDto.moduleCode;
            
            dbContext.SaveChanges();
            return Ok(Module);
        }
    }
}
