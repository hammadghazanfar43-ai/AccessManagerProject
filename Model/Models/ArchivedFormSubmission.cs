using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model

{
    public class ArchivedFormSubmission
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public string? CNIC { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? CountryCode { get; set; }
        public string? Email { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
