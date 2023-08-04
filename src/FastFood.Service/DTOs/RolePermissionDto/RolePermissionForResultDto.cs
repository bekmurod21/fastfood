using FastFood.Service.DTOs.PermissionDto;
using FastFood.Service.DTOs.RoleDto;

namespace FastFood.Service.DTOs.RolePermissionDto
{
    public class RolePermissionForResultDto
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public RoleForResultDto Role { get; set; }

        public long PermissonId { get; set; }
        public PermissionForResultDto Permisson { get; set; }
    }
}
