using ASMS.Domain;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Persistence.Abstractions
{
    public interface IComplexQueryRespository<TEntity, in TKey> : IQueryRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                               Expression<Func<TEntity, object>>? orderBy = null,
                                               int? take = null);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> query,
                                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                             Expression<Func<TEntity, object>>? orderBy = null,
                                             int? take = null);

        Task<TEntity?> FindSingleAsync(Expression<Func<TEntity, bool>> query,
                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

        Task<bool> FindExistAsync(Expression<Func<TEntity, bool>> query,
                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
    }
}