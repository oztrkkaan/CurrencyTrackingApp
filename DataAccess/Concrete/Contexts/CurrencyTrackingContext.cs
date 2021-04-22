using DataAccess.Concrete.EntityFramework.Mappings;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Contexts
{
    public class CurrencyTrackingContext : DbContext
    {
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrencyRating> CurrencyRatings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyMap());
            modelBuilder.ApplyConfiguration(new CurrencyRatingMap());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=CurrencyTrackingDb; Trusted_Connection=true");
        }
    }


}
