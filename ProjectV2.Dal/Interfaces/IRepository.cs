using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ProjectV2.Domain;

namespace ProjectV2.Dal.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByIdWithIncludeAsync(
            int id,
            params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IList<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetIQueryableAll();
        Task<int> SaveChangesAsync();
        Task AddAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
    }
}
