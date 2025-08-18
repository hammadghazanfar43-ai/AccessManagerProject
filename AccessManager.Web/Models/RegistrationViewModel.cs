using System.ComponentModel.DataAnnotations;

namespace AccessManager.Web.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "FirstName is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 chars allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 chars allowed")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 chars allowed")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 chars allowed")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(100, ErrorMessage = "Max 50 chars allowed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
