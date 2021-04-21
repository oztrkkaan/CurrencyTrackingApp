using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);

        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> filter = null);

        T Add(T entity);
        IList<T> AddRange(IList<T> entities);
        Task<IList<T>> AddRangeAsync(IList<T> entities);

        IList<T> UpdateRange(IList<T> entities);
        int Count(Expression<Func<T, bool>> filter = null);
        T Update(T entity);
        IList<T> DeleteRange(IList<T> entity);
        T Delete(T entity);
        bool Any(Expression<Func<T, bool>> filter);
    }
}
