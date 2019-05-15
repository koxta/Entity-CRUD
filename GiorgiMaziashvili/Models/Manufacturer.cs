using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiorgiMaziashvili.Models
{
    class Manufacturer
    {
        [Key]
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
