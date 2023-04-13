using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.UserDto;

public class UserForChangePassword
{
    [Required(ErrorMessage = "Value must not be null or empty!")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Old password must not be null or empty!")]
    public string OldPassword { get; set; }

    [Required(ErrorMessage = "New password must not be null or empty!")]
    public string Password { get; set; }
    [Compare(Password)]
    public string ConfirmPassword { get; set; }
}
