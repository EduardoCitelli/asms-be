﻿using ASMS.Domain;
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

        public IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                          Expression<Func<TEntity, object>>? orderBy = null)
        {
            var response = _dbSet.AsNoTracking();

            if (include != null)
                response = include(response);

            if (orderBy != null)
                response.OrderBy(orderBy);

            return response;
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> query,
                                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                        Expression<Func<TEntity, object>>? orderBy = null)
        {
            var response = _dbSet.AsNoTracking().Where(query);

            if (include != null)
                response = include(response);

            if (orderBy != null)
                response = response.OrderBy(orderBy);

            return response;
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

        public int GetCount(Expression<Func<TEntity, bool>>? query = null)
        {
            var response = _dbSet.AsNoTracking();
            
            if (query != null)                
                response.Where(query);

            return response.Count();
        }
    }
}