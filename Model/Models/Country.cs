using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model

{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Code { get; set; }

        public string Nationality { get; set; }

        public ICollection<City> Cities { get; set; }  // Navigation property
    }
}
