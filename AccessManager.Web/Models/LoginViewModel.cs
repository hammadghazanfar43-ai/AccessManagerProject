using System.ComponentModel.DataAnnotations;

namespace AccessManager.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 chars allowed")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(100, ErrorMessage = "Max 50 chars allowed")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
