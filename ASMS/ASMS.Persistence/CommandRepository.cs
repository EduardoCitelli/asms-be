using ASMS.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ASMS.Persistence
{
    public abstract class CommandRepository<TEntity>
        : BaseRepository<TEntity>, ICommandRepository<TEntity> where TEntity : class
    {
        protected CommandRepository(ASMSDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

        public async Task AddAsync(IEnumerable<TEntity> entities) => await _dbSet.AddRangeAsync(entities);

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Yield();
            _dbContext.Remove(entity);
        }

        public async Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            await Task.Yield();
            _dbContext.RemoveRange(entities);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Yield();
            _dbContext.Update(entity);
        }

        public async Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            await Task.Yield();
            _dbContext.UpdateRange(entities);
        }

        public void DetachEntity<TCommonEntity>(TCommonEntity entity) where TCommonEntity : class
        {
            var entry = _dbContext.Entry(entity);

            if (entry != null)
            {
                entry.State = EntityState.Detached;
            }
        }

        public void DetachEntity<TCommonEntity>(IEnumerable<TCommonEntity> entities) where TCommonEntity : class
        {
            foreach (var entity in entities)
            {
                var entry = _dbContext.Entry(entity);

                if (entry != null)
                    entry.State = EntityState.Detached;
            }
        }
    }
}