using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace GiorgiMaziashvili
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PhoneContext();

            string command = "";
            do
            {
                Console.WriteLine("Enter command");
                Console.WriteLine("C - Insert into database");
                Console.WriteLine("R - Read all entries from database");
                Console.WriteLine("U - Update entry");
                Console.WriteLine("D - Delete entry with id");
                Console.WriteLine("E - Exit program");

                command = Console.ReadLine();
                char c = command[0];

                if (c.Equals('R') || c.Equals('r'))
                {
                    Read(context);
                }
                else if (c.Equals('C') || c.Equals('c'))
                {
                    Insert(context);
                }
                else if (c.Equals('D') || c.Equals('d'))
                {
                    Delete(context);
                }
                else if (c.Equals('U') || c.Equals('u'))
                {
                    Update(context);
                }
                else if (c.Equals('E') || c.Equals('e'))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            } while (!command.Equals("e") || !command.Equals("E"));

            Console.WriteLine("Exiting program");
            Thread.Sleep(2000);
        }

        private static void Update(PhoneContext context)
        {
            Console.Clear();
            Console.WriteLine("Enter id to update");

            int id = Convert.ToInt32(Console.ReadLine());

            var phone = context.Phones.Where(p => p.PhoneID == id).First();

            var manufacturers = (from m in context.Manufacturers select m).ToList();
            foreach (var item in manufacturers)
            {
                Console.WriteLine(item.ManufacturerID + ": " + item.ManufacturerName);
            }
            Console.WriteLine("Enter Manufacturer id (Press enter to skip)");
            string manufacturerID = Console.ReadLine();

            if (!string.IsNullOrEmpty(manufacturerID))
            {
                int mId = Convert.ToInt32(manufacturerID);
                // modify manufacturer
                phone.Manufacturer = context.Manufacturers
                .Where(m => m.ManufacturerID == mId)
                .Select(m => m).First();
            }

            Console.WriteLine("Enter phone model (Press enter to skip)");
            string model = Console.ReadLine();

            if (!string.IsNullOrEmpty(model))
            {
                // modify model name
                phone.PhoneModel = model;
            }

            Console.WriteLine("Enter release date (Press enter to skip)");
            string date = Console.ReadLine();

            if (!string.IsNullOrEmpty(date))
            {
                // modify model date
                phone.Date = date;
            }

            Console.WriteLine("Enter operating system id (Press enter to skip)");
            var oss = (from o in context.OperatingSystems select o);
            foreach (var item in oss)
            {
                Console.WriteLine(item.OperatingSystemID + ": " + item.OperatingSystemName);
            }
            string osId = Console.ReadLine();

            if (!string.IsNullOrEmpty(osId))
            {
                int oid = Convert.ToInt32(osId);
                // modify os
                List<Models.OperatingSystem> operatingSystems = new List<Models.OperatingSystem>();
                operatingSystems.Add(context.OperatingSystems
                    .Where(o => o.OperatingSystemID == oid)
                    .Select(o => o).First());
            }

            context.SaveChanges();
        }

        private static void Delete(PhoneContext context)
        {
            Console.Clear();
            Console.WriteLine("Enter id to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            var phone = context.Phones.Where(p => p.PhoneID == id).First();

            context.Phones.Remove(phone);
            context.SaveChanges();
        }

        private static void Insert(PhoneContext context)
        {
            Console.Clear();
            Console.WriteLine("Insert in database");

            Console.WriteLine("Phone manufacturer (enter ID)");
            var manufacturers = (from m in context.Manufacturers select m).ToList();
            foreach (var item in manufacturers)
            {
                Console.WriteLine(item.ManufacturerID + ": " + item.ManufacturerName);
            }
            int manufacturerID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter phone model");
            string phoneModel = Console.ReadLine();

            Console.WriteLine("Phone operating system (enter ID)");
            var oss = (from o in context.OperatingSystems select o);
            foreach (var item in oss)
            {
                Console.WriteLine(item.OperatingSystemID + ": " + item.OperatingSystemName);
            }
            int osID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter phone release date");
            string date = Console.ReadLine();

            List<Models.OperatingSystem> operatingSystems = new List<Models.OperatingSystem>();
            operatingSystems.Add(context.OperatingSystems
                .Where(o => o.OperatingSystemID == osID)
                .Select(o => o).First());

            Models.Manufacturer manufacturer = context.Manufacturers
                .Where(m => m.ManufacturerID == manufacturerID)
                .Select(m => m).First();

            var p = new Models.Phone
            {
                Manufacturer = manufacturer,
                PhoneModel = phoneModel,
                Date = date,
                OperatingSystems = operatingSystems
            };
            context.Phones.Add(p);
            context.SaveChanges();
        }

        private static void Read(PhoneContext context)
        {
            Console.Clear();
            Console.WriteLine("Reading from database ...");
            var phones = (from p in context.Phones select p).ToList();

            if (phones.Count > 0)
            {
                foreach (var item in phones)
                {
                    Console.WriteLine($"{item.PhoneID}: {item.Manufacturer.ManufacturerName} - {item.PhoneModel}  ({item.Date})");
                    foreach (var os in item.OperatingSystems)
                    {
                        Console.WriteLine(os.OperatingSystemName);
                    }
                }
            }
            else
            {
                Console.WriteLine("No entries in DB");
            }
        }
    }
}



