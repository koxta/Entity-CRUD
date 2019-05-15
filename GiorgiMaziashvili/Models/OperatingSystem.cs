using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GiorgiMaziashvili.Models
{
    class OperatingSystem
    {
        [Key]
        public int OperatingSystemID { get; set; }
        public string OperatingSystemName { get; set; }
        public ICollection<Phone> Phones { get; set; }
    }
}
