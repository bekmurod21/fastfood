using FastFood.Domain.Commons;

namespace FastFood.Domain.Entities.Users;

public class Address:Auditable
{
    public string City { get; set; }
    public string Street { get; set; }
    public string Home { get; set; }
    public int Landmark { get; set; }
}
