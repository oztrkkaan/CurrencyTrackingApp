using DataAccess.Concrete.Contexts.EntityFramework.Mappings;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Contexts.EntityFramework
{
    public class CurrencyTrackingContext : DbContext
    {
        public virtual DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyMap());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=CurrencyTrackingDb; Trusted_Connection=true");
        }
    }


}
