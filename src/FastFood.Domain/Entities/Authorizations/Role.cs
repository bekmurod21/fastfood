using FastFood.Domain.Commons;

namespace FastFood.Domain.Entities.Authorizations;

public class Role:Auditable
{
    public string Name { get; set; }
}
