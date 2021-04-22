using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
   public class CurrencyRatingMap : IEntityTypeConfiguration<CurrencyRating>
    {
        public void Configure(EntityTypeBuilder<CurrencyRating> builder)
        {
            builder.ToTable("CurrencyRatings");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);
            builder.Property(p => p.CurrencyId);
            builder.Property(p => p.Date);
            builder.Property(p => p.Rating);
        }
    }
}
