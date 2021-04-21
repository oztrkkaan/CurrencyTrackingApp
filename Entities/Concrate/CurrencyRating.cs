using Core.Entities;
using System;

namespace Entities.Concrate
{
    public class CurrencyRating : IEntity
    {
        public int Id { get; set; }
        public decimal? Rating { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
