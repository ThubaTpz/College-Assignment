namespace EduCoreCRUD_Backend.Models
{
    public class UpdateModuleDto
    {
        public required string Name { get; set; }
        public required int Credits { get; set; }
        public required string ModuleCode { get; set; }
    }
}
