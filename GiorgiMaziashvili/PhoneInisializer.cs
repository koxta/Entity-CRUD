using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GiorgiMaziashvili
{
    class PhoneInisializer : DropCreateDatabaseAlways<PhoneContext>
    {
        protected override void Seed(PhoneContext context)
        {
            var os = new List<Models.OperatingSystem>()
            {
                new Models.OperatingSystem{OperatingSystemID = 1, OperatingSystemName= "Android"},
                new Models.OperatingSystem{OperatingSystemID = 2, OperatingSystemName= "IOS"},
            };

            var manufacturer = new List<Models.Manufacturer>()
            {
                new Models.Manufacturer{ ManufacturerID = 1, ManufacturerName = "Nokia"},
                new Models.Manufacturer{ ManufacturerID = 2, ManufacturerName = "Google"},
                new Models.Manufacturer{ ManufacturerID = 3, ManufacturerName = "Iphone"},
                new Models.Manufacturer{ ManufacturerID = 4, ManufacturerName = "HTC"},
                new Models.Manufacturer{ ManufacturerID = 5, ManufacturerName = "Sony"},
                new Models.Manufacturer{ ManufacturerID = 6, ManufacturerName = "Samsung"},
                new Models.Manufacturer{ ManufacturerID = 7, ManufacturerName = "Oneplus"},
            };

            context.OperatingSystems.AddRange(os);
            context.Manufacturers.AddRange(manufacturer);
            base.Seed(context);
        }
    }
}
