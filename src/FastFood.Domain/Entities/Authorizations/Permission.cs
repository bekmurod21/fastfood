using FastFood.Domain.Commons;

namespace FastFood.Domain.Entities.Authorizations;

public class Permission:Auditable
{
    public string Name { get; set; }
}
