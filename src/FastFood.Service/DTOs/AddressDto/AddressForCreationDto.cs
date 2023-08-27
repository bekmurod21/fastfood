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
    public long UserId { get; set; }

}
