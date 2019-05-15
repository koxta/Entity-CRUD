using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiorgiMaziashvili.Models
{
    class Phone
    {


        [Key]
        public int PhoneID { get; set; }
        public string PhoneModel { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Date { get; set; }
        public virtual ICollection<OperatingSystem> OperatingSystems { get; set; }
    }
}
