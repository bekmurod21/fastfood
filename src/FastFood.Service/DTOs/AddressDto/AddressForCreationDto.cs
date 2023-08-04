using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.AddressDto;

public class AddressForCreationDto
{
    [Required]
    public string District { get; set; }
    [Required]
    public string Street { get; set; }
    [Required]
    public int Home { get; set; }
    public string ZipCode { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public long UserId { get; set; }

}
