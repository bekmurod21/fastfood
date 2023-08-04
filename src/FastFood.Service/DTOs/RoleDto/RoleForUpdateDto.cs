using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.RoleDto
{
    public class RoleForUpdateDto
    {
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
