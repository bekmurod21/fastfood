using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.RolePermissionDto
{
    public class RolePermissionForCreationDto
    {
        [Required(ErrorMessage = "RoleId is required")]
        public long RoleId { get; set; }

        [Required(ErrorMessage = "PermissionId is required")]
        public long PermissonId { get; set; }
    }
}
