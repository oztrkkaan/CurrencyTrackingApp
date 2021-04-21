using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T>
        where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;
        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }
        public IQueryable<T> Table => this.Entities;
        protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
