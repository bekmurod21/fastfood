using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.RoleDto
{
    public class RoleForCreationDto
    {
        [Required]
        public string Name{get; set;}
    }
}
