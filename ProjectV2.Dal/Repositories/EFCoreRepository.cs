using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;

using ProjectV2.Dal.DataBaseContext;
using System.Linq.Expressions;

namespace ProjectV2.Dal.Repositories
{
    public class EFCoreRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ProjectDbContext _dbContext;
        private readonly IMapper _mapper;

        public EFCoreRepository(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var deleted = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Set<TEntity>().Remove(deleted);
            return deleted;
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public IQueryable<TEntity> GetIQueryableAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdWithIncludeAsync(
            int id,
            params Expression<Func<TEntity,object>>[] includeProperties)
        {
            var query = IncludeProperties(includeProperties);
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        private IQueryable<TEntity> IncludeProperties(
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> entities = _dbContext.Set<TEntity>();
            foreach (var property in includeProperties)
            {
                entities = entities.Include(property);
            }
            return entities;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}