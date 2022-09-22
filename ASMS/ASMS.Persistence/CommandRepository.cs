using ASMS.Persistence.Abstractions;

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

        public async Task AddCollectionAsync(IEnumerable<TEntity> entities) => await _dbSet.AddRangeAsync(entities);

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Yield();
            _dbContext.Remove(entity);
        }

        public async Task DeleteCollectionAsync(IEnumerable<TEntity> entities)
        {
            await Task.Yield();
            _dbContext.RemoveRange(entities);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Yield();
            _dbContext.Update(entity);
        }

        public async Task UpdateCollectionAsync(IEnumerable<TEntity> entities)
        {
            await Task.Yield();
            _dbContext.UpdateRange(entities);
        }
    }
}