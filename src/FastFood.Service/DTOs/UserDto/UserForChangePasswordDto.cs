using Org.BouncyCastle.Asn1.Mozilla;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.UserDto
{
    public class UserForChangePasswordDto
    {
        [Required(ErrorMessage ="Email is Required!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="OldPassword must not be null or empty!")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "NewPassword must not be null or empty!")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage ="ConfirmPassword must not ne null or empty!")]
        public string ConfirmPassword { get; set; }
    }
}
