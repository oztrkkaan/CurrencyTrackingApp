using Core.Entities;
using Entities.Abstract;

namespace Entities.Concrate
{
    public class CurrencyGroupItem : ISoftDelete, IEntity
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public int CurrencyGroupId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
