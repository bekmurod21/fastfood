using FastFood.Domain.Commons;

namespace FastFood.Domain.Entities.Authorizations;

public class RolePermission:Auditable
{
    public long RoleId { get; set; }
    public Role Roles { get; set; }

    public long PermissionId { get; set; }
    public Permission Permissions { get; set; }
}
