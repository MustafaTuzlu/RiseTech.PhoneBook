using Microsoft.EntityFrameworkCore;
using RiseTech.Data.Entities;

namespace RiseTech.Data
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
