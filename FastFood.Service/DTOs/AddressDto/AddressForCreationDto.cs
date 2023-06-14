using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.AddressDto;

public class AddressForCreationDto
{
    [Required]
    public string City { get; set; }

    [Required]
    public string Street { get; set; }

    [Required]
    public string Home { get; set; }
    public string Landmark { get; set; }
}
