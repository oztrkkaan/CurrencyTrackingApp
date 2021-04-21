using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
