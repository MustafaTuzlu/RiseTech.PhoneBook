using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RiseTech.Data.Entities;
using System.IO;

namespace RiseTech.Data
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ContactDb;User Id=postgres;Password=7F4df451mt!;");
            }
            base.OnConfiguring(optionsBuilder); 
        }
    }
}
