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

        public IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>>? include = null,
                                          Expression<Func<TEntity, object>>? orderBy = null,
                                          bool isDesc = false)
        {
            var response = _dbSet.AsQueryable().AsNoTracking();

            if (include != null)
                response = include(response);

            if (orderBy != null)
                response = isDesc ? response.OrderByDescending(orderBy).AsNoTracking() : response.OrderBy(orderBy).AsNoTracking();

            return response;
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> query,
                                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>>? include = null,
                                        Expression<Func<TEntity, object>>? orderBy = null,
                                        bool isDesc = false)
        {
            var response = _dbSet.Where(query).AsNoTracking();

            if (include != null)
                response = include(response);

            if (orderBy != null)
                response = isDesc ? response.OrderByDescending(orderBy).AsNoTracking() : response.OrderBy(orderBy).AsNoTracking();

            return response;
        }

        public async Task<bool> FindExistAsync(Expression<Func<TEntity, bool>> query,
                                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            if (include == null)
                return await _dbSet.AsNoTracking().AnyAsync(query);

            var queryable = include(_dbSet.AsNoTracking());

            return await queryable.AnyAsync(query);
        }

        public async Task<TEntity?> FindSingleAsync(Expression<Func<TEntity, bool>> query,
                                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                    Expression<Func<TEntity, object>>? orderBy = null,
                                                    bool isDesc = false)
        {
            if (include == null)
            {
                if (orderBy == null)
                    return await _dbSet.SingleOrDefaultAsync(query);

                return isDesc ? await _dbSet.OrderByDescending(orderBy)
                                            .AsNoTracking()
                                            .SingleOrDefaultAsync(query)
                              : await _dbSet.OrderBy(orderBy)
                                            .AsNoTracking()
                                            .SingleOrDefaultAsync(query);
            }

            var queryable = orderBy == null ? include(_dbSet.AsQueryable()) 
                                            : isDesc
                                            ? include(_dbSet.OrderByDescending(orderBy).AsQueryable())
                                            : include(_dbSet.OrderBy(orderBy).AsQueryable());

            return await queryable.SingleOrDefaultAsync(query);
        }

        public int GetCount(Expression<Func<TEntity, bool>>? query = null)
        {
            var response = _dbSet.AsNoTracking();

            if (query != null)
                response = response.Where(query).AsNoTracking();

            return response.Count();
        }
    }
}