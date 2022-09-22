using ASMS.Domain;
using ASMS.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Persistence
{
    public abstract class ComplexQueryRepository<TEntity, TKey>
        : QueryRepository<TEntity, TKey>, IComplexQueryRespository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public ComplexQueryRepository(ASMSDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                            Expression<Func<TEntity, object>>? orderBy = null,
                                                            int? take = null)
        {
            var response = _dbSet.AsNoTracking();

            if (include != null)
                response = include(response);

            if (orderBy != null)
                response.OrderBy(orderBy);

            if (take != null)
                response.Take(take.Value);

            return await response.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> query,
                                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                          Expression<Func<TEntity, object>>? orderBy = null,
                                                          int? take = null)
        {
            var queryable = _dbSet.AsNoTracking().Where(query);

            if (include != null)
                queryable = include(queryable);

            if (orderBy != null)
                queryable = queryable.OrderBy(orderBy);

            if (take != null)
                queryable = queryable.Take(take.Value);

            return await queryable.ToListAsync();
        }

        public async Task<bool> FindExistAsync(Expression<Func<TEntity, bool>> query,
                                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            if (include == null)
                return await _dbSet.AsNoTracking().AnyAsync(query);

            var queryable = include(_dbSet.AsQueryable());

            return await queryable.AnyAsync(query);
        }

        public async Task<TEntity?> FindSingleAsync(Expression<Func<TEntity, bool>> query,
                                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            if (include == null)
                return await _dbSet.SingleOrDefaultAsync(query);

            var queryable = include(_dbSet.AsQueryable());

            return await queryable.SingleOrDefaultAsync(query);
        }
    }
}