using FastFood.Domain.Commons;
using FastFood.Domain.Entities.Orders;

namespace FastFood.Domain.Entities.Users;

public class Address:Auditable
{
    public string District { get; set; }
    public string Street { get; set; }
    public int Home { get; set; }

    public ICollection<Order> Orders { get; set; }

}
