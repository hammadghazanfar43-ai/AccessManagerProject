using System;
using System.ComponentModel.DataAnnotations;

namespace Model

{
    public class FormSubmission
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? FatherName { get; set; }

        [Required]
        public string? CNIC { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? MaritalStatus { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public string? Nationality { get; set; }

        public string? Occupation { get; set; }

        public string? Gender { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? CountryCode { get; set; }

        public string? PicturePath { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? EmailStatus { get; set; }
    }
}
