using ASMS.Domain;
using System.Linq.Expressions;

namespace ASMS.Persistence.Abstractions
{
    public interface IQueryRepository<TEntity, in TKey> : ICommandRepository<TEntity> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id, Expression<Func<TEntity, object>>? include = null);

        Task<bool> ExistAsync(TKey id);

        Task<TEntity?> GetLastAsync();

        public IQueryable<TEntity> GetQueryable();
    }
}
