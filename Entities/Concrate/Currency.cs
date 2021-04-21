using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrate
{
    public class Currency : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerieCode { get; set; }
        public ICollection<CurrencyRating> CurrencyRates { get; set; }

    }
}
