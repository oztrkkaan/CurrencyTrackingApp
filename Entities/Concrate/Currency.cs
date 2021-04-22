using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrate
{
    public class Currency : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string OperationType { get; set; }
        public ICollection<CurrencyRating> CurrencyRatings { get; set; }

    }
}
