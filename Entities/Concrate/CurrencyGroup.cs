using Core.Entities;
using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrate
{
    public class CurrencyGroup : AuditableEntity, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        ICollection<CurrencyGroupItem> CurrencyGroupItems { get; set; }

    }
}
