using Microsoft.EntityFrameworkCore;

namespace ASMS.Persistence
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly ASMSDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ASMSDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
    }
}