using GiorgiMaziashvili.Models;
using System.Data.Entity;

namespace GiorgiMaziashvili
{
    class PhoneContext : DbContext
    {
        public PhoneContext() : base("PhoneDB")
        {
            Database.SetInitializer(new PhoneInisializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().Property(p => p.PhoneModel).HasMaxLength(50);
        }

        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Models.OperatingSystem> OperatingSystems  { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers  { get; set; }
    }
}
