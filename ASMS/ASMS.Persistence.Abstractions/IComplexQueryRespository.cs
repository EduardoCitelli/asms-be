using ASMS.Domain;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Persistence.Abstractions
{
    public interface IComplexQueryRespository<TEntity, in TKey> : IQueryRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                   Expression<Func<TEntity, object>>? orderBy = null);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> query,
                                 Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                 Expression<Func<TEntity, object>>? orderBy = null);

        Task<TEntity?> FindSingleAsync(Expression<Func<TEntity, bool>> query,
                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                       Expression<Func<TEntity, object>>? orderBy = null,
                                       bool isDesc = false);

        Task<bool> FindExistAsync(Expression<Func<TEntity, bool>> query,
                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

        int GetCount(Expression<Func<TEntity, bool>>? query = null);
    }
}