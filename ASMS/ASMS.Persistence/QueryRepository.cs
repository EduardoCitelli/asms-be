using ASMS.Domain;
using ASMS.Domain.Entities;
using ASMS.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Persistence
{
    public abstract class QueryRepository<TEntity, TKey>
        : CommandRepository<TEntity>, IQueryRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected QueryRepository(ASMSDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>>? include = null)
        {
            //var ids = id!.GetType()
            //             .GetProperties()
            //             .Select(x => x.GetValue(id))
            //             .ToList();

            //if (!ids.Any())
            //    ids.Add(id);

            var response = include is null ?
                await _dbSet.FindAsync(id) :
                await  include(_dbSet.AsNoTracking()).SingleOrDefaultAsync(x => x.Id!.Equals(id));

            if (response != null)
                _dbContext.Entry(response).State = EntityState.Detached;

            return response;
        }

        public async Task<bool> ExistAsync(TKey id) => await _dbSet.AnyAsync(x => x.Id!.Equals(id));

        public async Task<TEntity?> GetLastAsync() => await _dbSet.LastOrDefaultAsync();

        public IQueryable<TEntity> GetQueryable() => _dbSet.AsNoTracking();
    }
}