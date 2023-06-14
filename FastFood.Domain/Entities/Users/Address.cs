using FastFood.Domain.Commons;

namespace FastFood.Domain.Entities.Users;

public class Address:Auditable
{
    public string District { get; set; }
    public string Street { get; set; }
    public int Home { get; set; }
    public string ZipCode { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public long UserId { get; set; }
}
