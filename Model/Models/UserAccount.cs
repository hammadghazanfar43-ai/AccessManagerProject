using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Model

{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(UserName), IsUnique = true)]
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 chars allowed")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 chars allowed")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 chars allowed")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 chars allowed")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(100, ErrorMessage = "Max 100 chars allowed")]
        public required string Password { get; set; }
    }
}
    