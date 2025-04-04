using FastFood.Domain.Commons;

namespace FastFood.Domain.Entities.Companies;

public class Company : Auditable
{
    public string Name { get; set; }
}
