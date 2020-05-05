using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Data.Domain.Models;

namespace PhoneDirectory.Data.Persistence.Context
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(){}
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options){}
        public DbSet<Entry> Entries { get; set; }
        public DbSet<PhoneBook> PhoneBook { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=PhoneStoreDB;");
        }
    }
}
